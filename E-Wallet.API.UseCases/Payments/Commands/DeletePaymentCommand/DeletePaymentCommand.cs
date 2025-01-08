using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Commands.DeletePaymentCommand
{
    public class DeletePaymentCommand : IRequest<BaseResponse<bool>>
    {
        public int PaymentId { get; set; }
    }
}
