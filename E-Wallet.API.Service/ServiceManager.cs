using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Service.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _authenticationService;
        private readonly Lazy<IApplicationUserService> _applicationUserService;


        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider, IHostingEnvironment environment)
        {
            _authenticationService = new Lazy<IAuthService>(() => new AuthService(mapper, userManager, repositoryManager, configuration));
            _applicationUserService = new Lazy<IApplicationUserService>(() => new ApplicationUserService(repositoryManager, mapper, userManager));
        }
        public IAuthService AuthService => _authenticationService.Value;
        public IApplicationUserService ApplicationUserService => _applicationUserService.Value;

    }
}
