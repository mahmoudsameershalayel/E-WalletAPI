using E_Wallet.API.UseCases.DTOs.RechargePointDTOs;
using E_Wallet.API.UseCases.DTOs.TransactionDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Transactions.Queries.GetTransactionHistoryQuery
{
    public class GetTransactionHistoryQuery : IRequest<BaseResponse<IEnumerable<TransactionDto>>>
    {
        public int WalletId { get; set; }
    }
}
