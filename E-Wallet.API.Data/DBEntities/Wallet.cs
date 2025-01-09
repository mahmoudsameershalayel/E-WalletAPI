using E_Wallet.API.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.DBEntities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public WalletType? WalletType { get; set; }
        public CurrencyType? Currency { get; set; }
        public double Balance { get; set; }
        public IEnumerable<Recharge> Recharges { get; set; } = new List<Recharge>();
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
