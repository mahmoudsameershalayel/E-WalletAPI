using E_Wallet.API.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.DBEntities
{
    public class RechargePoint
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? LocationLat { get; set; }
        public double? LocationLong { get; set; }
        public string? PhoneNumber { get; set; }
        public IEnumerable<Recharge> Recharges { get; set; } = new List<Recharge>();
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
