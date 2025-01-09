using AutoMapper;
using Azure.Core;
using E_Wallet.API.Contracts;
using E_Wallet.API.Data.DBEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.RechargePoints.Commands.CrateRechargePointCommand
{
    public class CreateRechargePointHandler : IRequestHandler<CreateRechargePointCommand, BaseResponse<bool>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CreateRechargePointHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreateRechargePointCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var rechargePoint = _mapper.Map<RechargePoint>(request);
                var rechargePointUser = await _repositoryManager.ApplicationUser.CreateApplicationUserAsRechargePoint(request.Email, request.UserName , request.Password);
                rechargePoint.ApplicationUserId = rechargePointUser.Id;              
                _repositoryManager.RechargePointRepository.CreateRechargePoint(rechargePoint);
                await _repositoryManager.SaveAsync();
                response.Data = true;
                response.IsSuccess = true;
                response.Message = "The Recharge Point Created Successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
