using AutoMapper;
using E_Wallet.API.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases.Wallets.Commands.DeleteWalletCommand
{
    internal class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public DeleteWalletHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public Task<bool> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
throw new NotImplementedException();    
        }
    }
}
