using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.TransactionRepositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateTransaction(Transaction transaction) => Create(transaction);


        public void DeleteTransaction(Transaction transaction) => Delete(transaction);

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync() => await FindAll().ToListAsync();

        public async Task<Transaction> GetTransactionByIdAsync(int id) => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public async Task<IEnumerable<Transaction>> GetTransactionsHistoryForWallet(int walletId) => await FindByCondition(x => x.Wallet.Id == walletId || x.RecipientWalletId == walletId).Include(x => x.Wallet).ToListAsync();


        public void UpdateTransaction(Transaction transaction) => Update(transaction);

    }
}
