using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.ApplicationUserRepositories
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<Customer> GetCustomerByApplicationUserId(string userId)
        {
            var user =await GetApplicationUser(userId);
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.ApplicationUserId == user.Id);
            return customer;
        }



        public async Task<ApplicationUser> CreateApplicationUserAsRechargePoint(string email, string userName, string password)
        {
            var applicationUser = new ApplicationUser()
            {
                Email = email,
                UserName = userName,
                IsActive = true,
                userType = UserType.RechargePoint
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new Exception("The recharge point can not create!!!");
            }
            var rechargePoint = await _userManager.FindByNameAsync(userName);
            await _userManager.AddToRoleAsync(rechargePoint, "RechargePoint");
            return rechargePoint;

        }

        public async Task<ApplicationUser> CreateApplicationUserAsPaymentService(string email, string userName, string password)
        {
            var applicationUser = new ApplicationUser()
            {
                Email = email,
                UserName = userName,
                IsActive = true,
                userType = UserType.PaymentService
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                throw new Exception("The payment service can not create!!!");
            }
            var payment = await _userManager.FindByNameAsync(userName);
            await _userManager.AddToRoleAsync(payment, "Payment");
            return payment;
        }

        public async Task<ApplicationUser> GetApplicationUser(string? applicationUserId)
        {
            return (await _userManager.FindByIdAsync(applicationUserId));
        }

        public async Task<RechargePoint> GetRechargePointByApplicationUserId(string userId)
        {
            var user = await GetApplicationUser(userId);
            var rechargePoint = await _context.RechargePoints.FirstOrDefaultAsync(x => x.ApplicationUserId == user.Id);
            return rechargePoint;
        }

        public async Task<Payment> GetPaymentServiceByApplicationUserId(string userId)
        {
            var user = await GetApplicationUser(userId);
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.ApplicationUserId == user.Id);
            return payment;
        }




    }
}
