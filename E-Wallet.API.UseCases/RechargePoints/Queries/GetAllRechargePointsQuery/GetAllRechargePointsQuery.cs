using E_Wallet.API.UseCases.DTOs.RechargePointDTOs;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.RechargePoints.Queries.GetAllRechargePointsQuery
{
    public class GetAllRechargePointsQuery : IRequest<BaseResponse<IEnumerable<RechargePointDto>>>
    {

    }
}
