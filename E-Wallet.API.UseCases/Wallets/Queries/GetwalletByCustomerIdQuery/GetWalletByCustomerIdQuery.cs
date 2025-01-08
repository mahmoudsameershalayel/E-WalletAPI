using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.GetwalletByCustomerIdQuery
{
    public class GetWalletByCustomerIdQuery : IRequest<BaseResponse<IEnumerable<WalletDto>>>
    {
        public int CustomerId { get; set; }
    }
}
