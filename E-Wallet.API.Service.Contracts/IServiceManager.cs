using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Service.Contracts
{
    public interface IServiceManager
    {
        IApplicationUserService ApplicationUserService { get; }
        IAuthService AuthService { get; }
    }
}
