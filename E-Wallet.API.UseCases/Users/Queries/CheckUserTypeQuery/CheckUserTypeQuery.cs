using E_Wallet.API.Data.DBEntities;
using E_Wallet.API.Data.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Users.Queries.CheckUserTypeQuery
{
    public class CheckUserTypeQuery : IRequest<UserType>
    {
        public string? ApplicationUserId { get; set; }
    }
}
