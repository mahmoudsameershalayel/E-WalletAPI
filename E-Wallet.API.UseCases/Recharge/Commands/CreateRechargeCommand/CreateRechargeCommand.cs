using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Recharge.Commands.CreateRechargeCommand
{
    public class CreateRechargeCommand : IRequest<BaseResponse<string>>
    {
        public int WalletId { get; set; }
        public int RechargePointId { get; set; }
    }
}
