using E_Wallet.API.Contracts.ApplicationUserRepositories;
using E_Wallet.API.Contracts.PaymentRepositories;
using E_Wallet.API.Contracts.TransactionRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts
{
    public interface IRepositoryManager
    {
        IApplicationUserRepository ApplicationUser { get; }
        IPaymentRepository PaymentRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task SaveAsync();
    }
}
