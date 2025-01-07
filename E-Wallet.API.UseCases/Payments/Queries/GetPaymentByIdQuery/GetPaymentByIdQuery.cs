using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery
{
    public class GetPaymentByIdQuery : IRequest<BaseResponse<PaymentDto>>
    {
        public int PaymentId { get; set; }
    }
}
