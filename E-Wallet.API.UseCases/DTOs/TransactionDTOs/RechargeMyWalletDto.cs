using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.DTOs.TransactionDTOs
{
    public class RechargeMyWalletDto
    {
        public int YourWalletId { get; set; }
        public double Amount { get; set; }
        public int RechargePointWalletId { get; set; }
        public string? Details { get; set; }
    }
}
