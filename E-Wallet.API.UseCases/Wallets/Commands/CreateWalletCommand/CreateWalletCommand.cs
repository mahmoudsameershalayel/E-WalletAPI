using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Commands.CreateWalletCommand
{
    public class CreateWalletCommand : IRequest<BaseResponse<bool>>
    {
        public int? CustomerId { get; set; }
        public CurrencyType? Currency { get; set; }
    }
}
