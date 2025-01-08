using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.RechargePointRepositories
{
    public interface IRechargePointRepository
    {
        public Task<IEnumerable<RechargePoint>> GetAllRechargePointsAsync();
        public Task<RechargePoint> GetlRechargePointByIdAsync(int id);
        public void CreateRechargePoint(RechargePoint rechargePoint);
        public void UpdateRechargePoint(RechargePoint rechargePoint);
        public void DeleteRechargePoint(RechargePoint rechargePoint);
    }
}
