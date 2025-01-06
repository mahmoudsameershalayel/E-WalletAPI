using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Infrastructure.DTOs.AuthDTOs
{
    public class TokenDto
    {
        public TokenDto(string? AccessToken, string RefreshToken)
        {
            this.AccessToken = AccessToken;
            this.RefreshToken = RefreshToken;
        }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
