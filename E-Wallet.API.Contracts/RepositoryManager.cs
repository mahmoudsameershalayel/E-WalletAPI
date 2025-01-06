using E_Wallet.API.Contracts.ApplicationUserRepositories;
using E_Wallet.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IApplicationUserRepository> _applicationUser;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _applicationUser = new Lazy<IApplicationUserRepository>(() => new ApplicationUserRepository(context));
        }
        public IApplicationUserRepository ApplicationUser => _applicationUser.Value;

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
