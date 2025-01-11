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
        Task<IEnumerable<RechargePoint>> GetAllRechargePointsAsync();
        Task<RechargePoint> GetlRechargePointByIdAsync(int id);
        void CreateRechargePoint(RechargePoint rechargePoint);
        void UpdateRechargePoint(RechargePoint rechargePoint);
        void DeleteRechargePoint(RechargePoint rechargePoint);
    }
}
