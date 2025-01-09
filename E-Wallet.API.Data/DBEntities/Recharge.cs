using E_Wallet.API.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.DBEntities
{
    public class Recharge
    {
        public int Id { get; set; }
        public string? RechargeCode { get; set; }
        public RechargeCodeStatus? RechargeCodeStatus { get; set; }
        public int? RechargePointId { get; set; }
        public RechargePoint? RechargePoint { get; set; }
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
    }
}
