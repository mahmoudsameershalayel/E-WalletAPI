using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
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

        public void ActivateRechargeCode(string rechargeCode)
        {
            throw new NotImplementedException();
        }

        public void CreateRecharge(Recharge recharge) => Create(recharge);

        public void UpdateRecharge(Recharge recharge) => Update(recharge);
        public async Task<Recharge> GetRechargeByCode(string rechargeCode) => await FindByCondition(x => x.RechargeCode.Equals(rechargeCode)).FirstOrDefaultAsync();

    }
}
