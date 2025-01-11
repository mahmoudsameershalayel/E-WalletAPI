using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Exceptions.NotFoundExceptions
{
    public class RechargeNotFoundException : NotFoundException
    {
        public RechargeNotFoundException(string code) : base($"The Recharge code : {code} doesn't exist in the database.")
        {
        }
    }
}
