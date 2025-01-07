using E_Wallet.API.Service.Contracts;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_Wallet.API.UseCases.Payments.Queries.GetAllPaymentsQuery;
using E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery;
using E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_WalletAPI.Controllers
{

    public class TransactionController : BaseController
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        /// <summary>
        ///Create New Transaction 
        /// </summary>
        /// <param name="dto">The Transaction data.</param>
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> CreateTransaction([FromForm] CreateTransactionCommand command)
        {
            if (command is null) return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
    }
}
