using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.RechargeRepositories
{
    public class RechargeRepository : RepositoryBase<Recharge>, IRechargeRepository
    {
        public RechargeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateRecharge(Recharge recharge) => Create(recharge);
       
    }
}
