using E_Wallet.API.Contracts;
using E_Wallet.API.Data.Exceptions.NotFoundExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Recharge.Commands.UpdateRechargeCommand
{
    public class UpdateRechargeHandler : IRequestHandler<UpdateRechargeCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        public UpdateRechargeHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<bool> Handle(UpdateRechargeCommand request, CancellationToken cancellationToken)
        {
            var recharge = await _repositoryManager.RechargeRepository.GetRechargeByCode(request.RechargeCode);
            if (recharge is null) throw new RechargeNotFoundException(request.RechargeCode);
            recharge.IsRecharged = request.isRecharged;
            _repositoryManager.RechargeRepository.UpdateRecharge(recharge);
            await _repositoryManager.SaveAsync();
            return true;
        }
    }
}
