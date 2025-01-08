using E_Wallet.API.Contracts.ApplicationUserRepositories;
using E_Wallet.API.Contracts.PaymentRepositories;
using E_Wallet.API.Contracts.RechargePointRepositories;
using E_Wallet.API.Contracts.TransactionRepositories;
using E_Wallet.API.Contracts.WalletRepositories;
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
        IWalletRepository WalletRepository { get; }
        IRechargePointRepository RechargePointRepository { get; }
        Task SaveAsync();
    }
}
