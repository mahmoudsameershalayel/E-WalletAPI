using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Contracts.ApplicationUserRepositories
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetApplicationUser(string applicationUserId);
        Task<ApplicationUser> CreateApplicationUserAsRechargePoint(string email , string userName , string password);
        Task<ApplicationUser> CreateApplicationUserAsPaymentService(string email ,string userName, string password);
        Task<Customer> GetCustomerByApplicationUserId(string userId);
        Task<RechargePoint> GetRechargePointByApplicationUserId(string userId);
        Task<Payment> GetPaymentServiceByApplicationUserId(string userId);
    }
}
