using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.DTOs.TransactionDTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int? SenderWalletId { get; set; }
        public string? TransactionType { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public int? RecipientWalletId { get; set; }
        public string? Details { get; set; }
        public string? CreatedAtDate { get; set; }
        public string? CreatedAtTime { get; set; }
    }
}
