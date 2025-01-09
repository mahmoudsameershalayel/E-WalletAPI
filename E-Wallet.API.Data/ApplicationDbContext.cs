using E_Wallet.API.Data.DBEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Wallet.API.Data.Configurations;
using E_Wallet.API.Data.Enums;

namespace E_Wallet.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfigureUserCustomerRelationship());
            modelBuilder.ApplyConfiguration(new ConfigureWalletTransactionRelationship());
            modelBuilder.ApplyConfiguration(new ConfigureUserPaymentRelationship());
            modelBuilder.ApplyConfiguration(new ConfigureUserRechargePointRelationship());

            string ADMIN_ID = "02174cf0-9412-4cfe-afbf-59f706d72cf6";
            string ADMIN_ROLE_ID = "341743f0-9427-42de-afbf-59f706d72cf6";
            string CUSTOMER_ROLE_ID = "341743f0-8ce4-42de-afbf-59f706d72cf6";
            string RECHARGEPOINT_ROLE_ID = "478543f7-8ce4-42de-afbf-59f706d72cf6";
            string PAYMENTSERVICE_ROLE_ID = "786743f1-1ce8-73de-afbf-29f706d72cf6";

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = ADMIN_ROLE_ID,
                    ConcurrencyStamp = ADMIN_ROLE_ID
                }, new IdentityRole
                {
                    Name = "RechargePoint",
                    NormalizedName = "RECHARGEPOINT",
                    Id = RECHARGEPOINT_ROLE_ID,
                    ConcurrencyStamp = RECHARGEPOINT_ROLE_ID
                }, new IdentityRole
                {
                    Name = "Payment",
                    NormalizedName = "PAYMENT",
                    Id = PAYMENTSERVICE_ROLE_ID,
                    ConcurrencyStamp = PAYMENTSERVICE_ROLE_ID
                }, new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    Id = CUSTOMER_ROLE_ID,
                    ConcurrencyStamp = CUSTOMER_ROLE_ID
                }
           );

            
            //create admin user
            var appUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin_10",
                PhoneNumber = "1234567890",
                LocationLat = "test",
                LocationLong = "test",
                Address = "admin address",
                NormalizedUserName = "ADMIN_10" ,
                userType = UserType.Admin
            };


            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "admin123456");
            //seed user
            modelBuilder.Entity<ApplicationUser>().HasData(appUser);

            

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<RechargePoint> RechargePoints { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}