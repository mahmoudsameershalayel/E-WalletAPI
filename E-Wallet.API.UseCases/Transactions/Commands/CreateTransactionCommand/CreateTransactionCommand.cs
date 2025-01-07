using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand
{
    public class CreateTransactionCommand : IRequest<BaseResponse<bool>>
    {
        public int? WalletId { get; set; }
        public TransactionType? TransactionType { get; set; }
        public double? Amount { get; set; }
        public int? RecipientWalletId { get; set; }
        public string? Details { get; set; }
    }
}
