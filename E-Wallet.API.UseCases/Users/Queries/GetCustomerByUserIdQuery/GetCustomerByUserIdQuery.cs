using E_Wallet.API.Data.DBEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery
{
    public class GetCustomerByUserIdQuery : IRequest<Customer>
    {
        public string? ApplicationUserId { get; set; }
    }
}
