using E_Wallet.API.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Wallet.API.Data.DBEntities
{
    public class Transaction
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Wallet))]
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
        public TransactionType? TransactionType { get; set; }
        public double? Amount { get; set; }
        [ForeignKey(nameof(RecipientWallet))]
        public int? RecipientWalletId { get; set; }
        public Wallet? RecipientWallet { get; set; }
        public string? Details { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
