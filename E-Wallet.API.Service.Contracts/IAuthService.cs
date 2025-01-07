using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using E_Wallet.API.UseCases.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Service.Contracts
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(UserForRegisterDto dto);
        Task<bool> ValidateUser(UserForAuthDto dto);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<string> GenerateOtp(string username);
        Task<bool> VerifyOtp(string username, string enteredOtp);
        Task CreateCustomer(string UserId);
        Task<string> EditProfileAsync(string currentUserId, UpdateProfileDto dto);
        Task<bool> IsCustomer(string userId);
        Task<ApplicationUserDto> GetProfileAsync(string currentUserId);
        Task<string> ForgotPasswordAsync(ForgetPasswordDto dto);
        Task<string> ResetPasswordAsync(string email, string token, string newPassword);
        Task<string> ChangePasswordAsync(string currentUserId, string oldPassword, string newPassword);
        Task<string> DeleteAccountAsync(string currentUserId);
    }
}
