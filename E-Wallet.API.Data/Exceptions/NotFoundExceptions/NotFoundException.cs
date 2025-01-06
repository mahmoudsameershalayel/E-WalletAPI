using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Exceptions.NotFoundExceptions
{
    public class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message) { }

    }
}
