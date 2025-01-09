﻿using E_Wallet.API.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.RechargeRepositories
{
    public interface IRechargeRepository
    {
        public void CreateRecharge(Recharge recharge);
    }
}
