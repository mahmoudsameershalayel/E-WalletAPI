using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.GetWalletsByApplicationUserIdQuery
{
    public class GetWalletByApplicationUserIdHandler : IRequestHandler<GetWalletByApplicationUserIdQuery, BaseResponse<IEnumerable<WalletDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetWalletByApplicationUserIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<WalletDto>>> Handle(GetWalletByApplicationUserIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<WalletDto>>();
            var wallets = await _repositoryManager.WalletRepository.GetWalletsByApplicationUserId(request.ApplicationUserId);
            response.Data = _mapper.Map<List<WalletDto>>(wallets);
            response.IsSuccess = true;
            response.Message = "The Wallets Recieved Successfully";
            return response;
        }
    }
}