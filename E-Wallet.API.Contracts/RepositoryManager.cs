﻿using E_Wallet.API.Contracts.ApplicationUserRepositories;
using E_Wallet.API.Contracts.PaymentRepositories;
using E_Wallet.API.Contracts.TransactionRepositories;
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
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<ITransactionRepository> _transactionRepository;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _applicationUser = new Lazy<IApplicationUserRepository>(() => new ApplicationUserRepository(context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(context));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(context));
        }
        public IApplicationUserRepository ApplicationUser => _applicationUser.Value;

        public IPaymentRepository PaymentRepository => _paymentRepository.Value;
        public ITransactionRepository TransactionRepository => _transactionRepository.Value;
        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
