using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using E_Wallet.API.UseCases.DTOs.AuthDTOs;
using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using E_Wallet.API.Data.Enums;

namespace E_Wallet.API.Service
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepositoryManager _repositoryManager;
        private ApplicationUser? _user;
        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager,IRepositoryManager repositoryManager , IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _repositoryManager = repositoryManager;
        }
        public async Task<string> ChangePasswordAsync(string currentUserId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(currentUserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Password change failed");
            }

            return "Password changed successfully.";
        }

        public async Task CreateCustomer(string UserId)
        {
            var customer = new Customer
            {
                ApplicationUserId = UserId,
            };
            _repositoryManager.CustomerRepository.CreateCustomer(customer);
            _repositoryManager.SaveAsync();
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;
            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(60);
            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken, refreshToken);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:TokenKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.NameIdentifier , _user.Id),
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;

        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var isAdmin = claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Administrator");

            var isSystemAdmin = claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "SystemAdministrator");
            var expiration = (isAdmin || isSystemAdmin) ? DateTime.Now.AddYears(100) : DateTime.Now.AddMinutes(60);

            var tokenOptions = new JwtSecurityToken
            (
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public Task<string> DeleteAccountAsync(string currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditProfileAsync(string currentUserId, UpdateProfileDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ForgotPasswordAsync(ForgetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (dto.PhoneNumber != user.PhoneNumber)
            {
                throw new Exception("User data not accepted");
            }
            if (dto.NewPassword != dto.ConfirmNewPassword)
            {
                throw new Exception("The confirm password must be equal to password");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exception("FAILED : The password length must be 8 at least and the password contain digit.");
            }
            user.IsActive = false;
            await _userManager.UpdateAsync(user);
            return "The new password assign successfully you must wait until the ADMINISTRATOR Activate your account then you will can login with username and new password.";
        }

        public Task<string> GenerateOtp(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUserDto> GetProfileAsync(string currentUserId)
        {
            var user = await _userManager.FindByIdAsync(currentUserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var userDto = _mapper.Map<ApplicationUserDto>(user);
            return userDto;
        }

        public async Task<bool> IsCustomer(string userId)
        {
            var customers = await _repositoryManager.CustomerRepository.GetAllCustomersAsync();
            foreach (Customer cust in customers)
            {
                if (cust.ApplicationUserId.Equals(userId))
                {
                    return true;
                }
            }
            return false;
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:TokenKey").Value)),
                ValidateLifetime = true,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
            securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {

            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken)
            {
                throw new SecurityTokenException("Invalid refresh token.");
            }

            _user = user;
            var newRefreshToken = GenerateRefreshToken();
            _user.RefreshToken = newRefreshToken;
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(60); 

            await _userManager.UpdateAsync(_user);  

            return await CreateToken(populateExp: false);
        }

        public async Task<IdentityResult> RegisterUser(UserForRegisterDto dto)
        {
            var user = _mapper.Map<ApplicationUser>(dto);
            user.IsActive = true;
            user.userType = UserType.Customer;
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                var customer = await _userManager.FindByNameAsync(dto.UserName);
                await _userManager.AddToRoleAsync(customer, "Customer");
                await CreateCustomer(customer.Id);
            }

            return result;
        }

        public async Task<string> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Password reset failed");
            }

            return "Password has been reset successfully.";
        }

        public async Task<bool> ValidateUser(UserForAuthDto dto)
        {
            _user = await _userManager.FindByNameAsync(dto.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, dto.Password));
            return result;
        }

        public Task<bool> VerifyOtp(string username, string enteredOtp)
        {
            throw new NotImplementedException();
        }
    }
}
