using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Recharge.Commands.UpdateRechargeCommand
{
    public class UpdateRechargeCommand : IRequest<bool>
    {
        public string RechargeCode { get; set; }
        public bool isRecharged { get; set; }
    }
}
