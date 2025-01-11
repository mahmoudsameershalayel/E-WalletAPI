using E_Wallet.API.Contracts;
using E_Wallet.API.Data.Enums;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.RechargePoints.Commands.ActivateRechargeCodeCommand
{
    public class ActivateRechargeCodeHandler : IRequestHandler<ActivateRechargeCodeCommand, BaseResponse<bool>>
    {
        private readonly IRepositoryManager _repositorymanager;
        public ActivateRechargeCodeHandler(IRepositoryManager repositoryManager)
        {
            _repositorymanager = repositoryManager;
        }
        public async Task<BaseResponse<bool>> Handle(ActivateRechargeCodeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            var recharge = await _repositorymanager.RechargeRepository.GetRechargeByCode(request.RechargeCode);
            if (recharge is null) throw new RechargeNotFoundException(request.RechargeCode);
            var rechargeWallet = _repositorymanager.WalletRepository.GetWalletByIdAsync(recharge.RechargeWalletId);
            if (rechargeWallet is null) throw new WalletNotFoundException(recharge.RechargeWalletId);

            recharge.RechargeCodeStatus = RechargeCodeStatus.Active;
            _repositorymanager.RechargeRepository.UpdateRecharge(recharge);
            await _repositorymanager.SaveAsync();
            response.Data = true;
            response.IsSuccess = true;
            response.Message = "The recharge code ACTIVATED successfully";
            return response;
        }
    }
}
