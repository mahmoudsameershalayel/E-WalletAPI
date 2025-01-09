using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.DTOs.RechargePointDTOs
{
    public class RechargePointDto
    {
        public int Id { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? LocationLat { get; set; }
        public double? LocationLong { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CreatedAtDate { get; set; }
        public string? CreatedAtTime { get; set; }
        public IEnumerable<WalletDto> wallets { get; set; } = new List<WalletDto>();    
    }
}
