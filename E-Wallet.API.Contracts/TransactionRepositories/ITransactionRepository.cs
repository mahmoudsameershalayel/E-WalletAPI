using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.TransactionRepositories
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        public Task<IEnumerable<Transaction>> GetTransactionsHistoryForCustomer(int customerId);
        public Task<Transaction> GetTransactionByIdAsync(int id);
        public void CreateTransaction(Transaction transaction);
        public void UpdateTransaction(Transaction transaction);
        public void DeleteTransaction(Transaction transaction);
    }
}
