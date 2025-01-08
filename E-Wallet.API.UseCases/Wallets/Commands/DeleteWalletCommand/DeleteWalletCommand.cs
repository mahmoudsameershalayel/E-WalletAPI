using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Commands.DeleteWalletCommand
{
    internal class DeleteWalletCommand : IRequest<bool>
    {
        public int WalletId { get; set; }
    }
}