using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.DTOs.AuthDTOs
{
    public class ForgetPasswordDto
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
