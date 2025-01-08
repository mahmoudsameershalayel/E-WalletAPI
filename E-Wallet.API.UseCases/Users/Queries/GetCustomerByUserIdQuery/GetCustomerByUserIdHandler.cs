using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using E_Wallet.API.UseCases.DTOs.PaymentDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery
{
    public class GetCustomerByUserIdHandler : IRequestHandler<GetCustomerByUserIdQuery, Customer>
    {
        private readonly IRepositoryManager _repositoryManager;
        public GetCustomerByUserIdHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<Customer> Handle(GetCustomerByUserIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(request.ApplicationUserId);
            if (customer is null) throw new ApplicationUserNotFoundException(request.ApplicationUserId);
            return customer;
        }
    }
}
