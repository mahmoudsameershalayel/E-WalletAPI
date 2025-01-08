using E_Wallet.API.Data.Enums;
using E_Wallet.API.Service.Contracts;
using E_Wallet.API.UseCases.DTOs.TransactionDTOs;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_Wallet.API.UseCases.Payments.Queries.GetAllPaymentsQuery;
using E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery;
using E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand;
using E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery;
using E_Wallet.API.UseCases.Wallets.Queries.CheckCustomerWalletQuery;
using E_Wallet.API.UseCases.Wallets.Queries.GetwalletByCustomerIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        ///Make Transfer between two wallets 
        /// </summary>
        /// <param name="dto">The Transaction data.</param>
        [HttpPost]
        [Authorize(Roles = "Customer")]

        public async Task<IActionResult> MakeTransfer([FromForm] MakeTransferDto dto)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new CheckCustomerWalletQuery() { ApplicationUserId = currentUserId, WalletId = dto.YourWalletId });
            if (!result) return BadRequest("The wallet you try send money from it NOT FOR YOU!!");
            var response = await _mediator.Send(new CreateTransactionCommand() { WalletId = dto.YourWalletId, RecipientWalletId = dto.RecipientWalletId, TransactionType = TransactionType.Transfer, Amount = dto.Amount, Details = dto.Details });
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        /// <summary>
        ///Make Payment 
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Customer")]

        public async Task<IActionResult> MakePayment([FromForm] MakePaymentDto dto)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new CheckCustomerWalletQuery() { ApplicationUserId = currentUserId, WalletId = dto.YourWalletId });
            if (!result) return BadRequest("The wallet you try pay money from it NOT FOR YOU!!");
            var response = await _mediator.Send(new CreateTransactionCommand() { WalletId = dto.YourWalletId, RecipientWalletId = null, TransactionType = TransactionType.Payment, Amount = dto.Amount, Details = dto.Details });
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
