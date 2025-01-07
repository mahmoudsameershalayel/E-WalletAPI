using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Payments.Queries.GetAllPaymentsQuery
{
    public class GetAllPaymentsQuery :IRequest<BaseResponse<IEnumerable<PaymentDto>>>
    {
    }
}
