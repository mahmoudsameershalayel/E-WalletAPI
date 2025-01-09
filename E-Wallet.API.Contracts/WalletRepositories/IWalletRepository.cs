using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.WalletRepositories
{
    public interface IWalletRepository
    {
        public Task<IEnumerable<Wallet>> GetAllWalletsAsync();
        public Task<Wallet> GetWalletByIdAsync(int? id);
        public Task<IEnumerable<Wallet>> GetWalletsByApplicationUserId(string applicationUserId);
        public void CreateWallet(Wallet wallet);
        public void UpdateWallet(Wallet wallet);
        public void DeleteWallet(Wallet wallet);
    }
}
