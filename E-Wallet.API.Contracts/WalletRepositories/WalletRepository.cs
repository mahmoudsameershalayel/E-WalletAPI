using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.WalletRepositories
{
    public class WalletRepository : RepositoryBase<Wallet>, IWalletRepository
    {
        public WalletRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateWallet(Wallet wallet) => Create(wallet);


        public void DeleteWallet(Wallet wallet) => Delete(wallet);


        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync() => await FindAll().ToListAsync();


        public async Task<Wallet> GetWalletByIdAsync(int? id) => await FindByCondition(x => x.Id == id).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).FirstOrDefaultAsync();


        public async Task<IEnumerable<Wallet>> GetWalletByCustomerId(int customerId) => await FindByCondition(x => x.CustomerId == customerId).Include(x => x.Customer).ThenInclude(x => x.ApplicationUser).ToListAsync();
        public void UpdateWallet(Wallet wallet) => Update(wallet);

       
    }
}
