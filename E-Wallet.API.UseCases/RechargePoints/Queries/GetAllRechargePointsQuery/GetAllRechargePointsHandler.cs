using AutoMapper;
using E_Wallet.API.Contracts;
using E_Wallet.API.UseCases.DTOs.RechargePointDTOs;
using E_Wallet.API.UseCases.DTOs.WalletDTOs;
using E_Wallet.API.UseCases.Wallets.Queries.GetAllWalletsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.RechargePoints.Queries.GetAllRechargePointsQuery
{
    public class GetAllRechargePointsHandler : IRequestHandler<GetAllRechargePointsQuery, BaseResponse<IEnumerable<RechargePointDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllRechargePointsHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<RechargePointDto>>> Handle(GetAllRechargePointsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<RechargePointDto>>();
            var rechargePoints = await _repositoryManager.RechargePointRepository.GetAllRechargePointsAsync();
            response.Data = _mapper.Map<List<RechargePointDto>>(rechargePoints);
            response.IsSuccess = true;
            response.Message = "All Recharge Points Recieved successfully";
            return response;

        }
    }
}
