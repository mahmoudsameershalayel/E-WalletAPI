using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.DTOs.TransactionDTOs
{
    public class MakePaymentDto
    {
        public int YourWalletId { get; set; }
        public double Amount { get; set; }
        public string? Details { get; set; }
    }
}
