using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.RechargePoints.Commands.CrateRechargePointCommand
{
    public class CreateRechargePointCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? LocationLat { get; set; }
        public double? LocationLong { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }
    }
}
