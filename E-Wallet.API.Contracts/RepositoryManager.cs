﻿using E_Wallet.API.Contracts.ApplicationUserRepositories;
using E_Wallet.API.Contracts.CustomerRepositories;
using E_Wallet.API.Contracts.PaymentRepositories;
using E_Wallet.API.Contracts.RechargePointRepositories;
using E_Wallet.API.Contracts.RechargeRepositories;
using E_Wallet.API.Contracts.TransactionRepositories;
using E_Wallet.API.Contracts.WalletRepositories;
using E_Wallet.API.Data;
using E_Wallet.API.Data.DBEntities;
using Microsoft.AspNetCore.Identity;
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
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<IWalletRepository> _walletRepository;
        private readonly Lazy<ITransactionRepository> _transactionRepository;
        private readonly Lazy<IRechargePointRepository> _rechargePointRepository;
        private readonly Lazy<IRechargeRepository> _rechargeRepository;
        public RepositoryManager(ApplicationDbContext context , UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _applicationUser = new Lazy<IApplicationUserRepository>(() => new ApplicationUserRepository(context , userManager));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(context));
            _transactionRepository = new Lazy<ITransactionRepository>(() => new TransactionRepository(context));
            _walletRepository = new Lazy<IWalletRepository>(() => new WalletRepository(context));
            _rechargePointRepository = new Lazy<IRechargePointRepository>(() => new RechargePointRepository(context));
            _rechargeRepository = new Lazy<IRechargeRepository>(() => new RechargeRepository(context));
        }
        public IApplicationUserRepository ApplicationUser => _applicationUser.Value;
        public ICustomerRepository CustomerRepository => _customerRepository.Value;
        public IPaymentRepository PaymentRepository => _paymentRepository.Value;
        public ITransactionRepository TransactionRepository => _transactionRepository.Value;
        public IWalletRepository WalletRepository => _walletRepository.Value;
        public IRechargePointRepository RechargePointRepository => _rechargePointRepository.Value;
        public IRechargeRepository RechargeRepository => _rechargeRepository.Value;
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
