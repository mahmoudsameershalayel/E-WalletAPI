using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using E_Wallet.API.UseCases.DTOs.RechargeDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Recharge.Queries.GetRechargeByRechargeCodeQuery
{
    public class GetRechargeByCodeQuery : IRequest<BaseResponse<RechargeDto>>
    {
        public string? RechargeCode { get; set; }
    }
}
