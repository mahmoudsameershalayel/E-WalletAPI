﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.DTOs.WalletDTOs
{
    public class WalletDto
    {
        public int Id { get; set; }
        public string? OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public double Balance { get; set; }
        public string? Currency { get; set; }
        public string? CreatedAtDate { get; set; }
        public string? CreatedAtTime { get; set; }
       
    }
}
