using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.GetWalletByIdQuery
{
    public class GetWalletByIdQuery : IRequest<BaseResponse<WalletDto>>
    {
        public int WalletId { get; set; }
    }
}
