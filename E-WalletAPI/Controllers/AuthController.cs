using E_Wallet.API.UseCases.DTOs.ApplicationUserDTOs;
using E_Wallet.API.UseCases.DTOs.AuthDTOs;
using E_Wallet.API.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_WalletAPI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IServiceManager _service;

        public AuthController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var profile = await _service.AuthService.GetProfileAsync(currentUserId);

               
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] UpdateProfileDto dto)
        {
            try
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _service.AuthService.EditProfileAsync(currentUserId, dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// register new user with Customer roles
        /// </summary>
        /// <param name="dto">The Application user data.</param>
        /// <returns>status code.</returns>
        /// <response code="201">The user created successfully.</response>
        /// <response code="400">Model state is not valid.</response>
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegisterDto dto)
        {
            var result = await _service.AuthService.RegisterUser(dto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        /// <summary>
        ///Login operation
        /// </summary>
        /// <param name="dto">The authentication data.</param>
        /// <response code="401">Authentication failed unauthorized.</response>
        /// <response code="200">Authenticate successfullay and return the TOKEN DTO{access token , refresh token} directly.</response>
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]UserForAuthDto dto)
        {
            var user = await _service.ApplicationUserService.GetUserByName(dto.UserName);
            var result = await _service.AuthService.ValidateUser(dto);
            if (!result)
            {
                return BadRequest(new { error = "Invalid credentials!" });
            }
            if (!user.IsActive)
            {
                return Unauthorized(new { error = "The user account is not active!" });
            }
            var tokenDto = await _service.AuthService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordDto dto)
        {
            try
            {
                var result = await _service.AuthService.ForgotPasswordAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            try
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _service.AuthService.ChangePasswordAsync(currentUserId, dto.OldPassword, dto.NewPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <param name="tenantId">PASS the TENANT ID in PATH</param>
        [HttpDelete("{tenantId}")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount(string tenantId)
        {
            try
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _service.AuthService.DeleteAccountAsync(currentUserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
