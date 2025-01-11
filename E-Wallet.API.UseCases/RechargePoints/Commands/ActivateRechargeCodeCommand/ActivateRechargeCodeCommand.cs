using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.RechargePoints.Commands.ActivateRechargeCodeCommand
{
    public class ActivateRechargeCodeCommand : IRequest<BaseResponse<bool>>
    {
        public string ApplicationUserId { get; set; }
        public string RechargeCode { get; set; }
    }
}
