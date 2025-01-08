using AutoMapper;
using Azure;
using E_Wallet.API.Contracts;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Queries.GetAllWalletsQuery
{
    public class GetAllWalletsHandler : IRequestHandler<GetAllWalletsQuery , BaseResponse<IEnumerable<WalletDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllWalletsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<WalletDto>>> Handle(GetAllWalletsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<WalletDto>>();
            var wallets = await _repositoryManager.WalletRepository.GetAllWalletsAsync();
            response.Data = _mapper.Map<List<WalletDto>>(wallets);
            response.IsSuccess = true;
            response.Message = "All Wallets recieved successfully";
            return response;
            
        }
    }
}
