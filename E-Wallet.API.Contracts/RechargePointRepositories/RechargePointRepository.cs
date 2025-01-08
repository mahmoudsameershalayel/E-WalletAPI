using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.RechargePointRepositories
{
    public class RechargePointRepository : RepositoryBase<RechargePoint> , IRechargePointRepository
    {
        public RechargePointRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateRechargePoint(RechargePoint rechargePoint) => Create(rechargePoint);


        public void DeleteRechargePoint(RechargePoint rechargePoint) => Delete(rechargePoint);


        public async Task<IEnumerable<RechargePoint>> GetAllRechargePointsAsync() =>await FindAll().ToListAsync();


        public async Task<RechargePoint> GetlRechargePointByIdAsync(int id) => await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();


        public void UpdateRechargePoint(RechargePoint rechargePoint) => Update(rechargePoint);

    }
}
