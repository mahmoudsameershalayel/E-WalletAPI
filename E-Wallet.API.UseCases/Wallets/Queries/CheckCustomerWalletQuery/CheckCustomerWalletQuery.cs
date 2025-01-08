using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.CheckCustomerWalletQuery
{
    public class CheckCustomerWalletQuery : IRequest<bool>
    {
        public string? ApplicationUserId { get; set; }
        public int WalletId { get; set; }
    }
}