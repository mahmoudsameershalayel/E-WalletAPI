using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Users.Queries.CheckUserTypeQuery
{
    public class CheckUserTypeHandler : IRequestHandler<CheckUserTypeQuery, UserType>
    {
        private readonly IRepositoryManager _repositoryManager;
        public CheckUserTypeHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<UserType> Handle(CheckUserTypeQuery request, CancellationToken cancellationToken)
        {
            var user = await _repositoryManager.ApplicationUser.GetApplicationUser(request.ApplicationUserId);
            if (user is null) throw new ApplicationUserNotFoundException(request.ApplicationUserId);
            return user.userType;
        }
    }
}