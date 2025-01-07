using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
