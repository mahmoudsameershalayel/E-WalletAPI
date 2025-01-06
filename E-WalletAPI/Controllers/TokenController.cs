using E_Wallet.API.Infrastructure.DTOs.AuthDTOs;
using E_Wallet.API.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_WalletAPI.Controllers
{
 
    public class TokenController : BaseController
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
