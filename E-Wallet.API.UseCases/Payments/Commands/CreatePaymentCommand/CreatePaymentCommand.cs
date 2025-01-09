using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
