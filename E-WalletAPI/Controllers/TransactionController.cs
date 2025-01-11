using E_Wallet.API.Data.Enums;
using E_Wallet.API.Service.Contracts;
using E_Wallet.API.UseCases.DTOs.TransactionDTOs;
using E_Wallet.API.UseCases.Payments.Commands.CreatePaymentCommand;
using E_Wallet.API.UseCases.Payments.Queries.GetAllPaymentsQuery;
using E_Wallet.API.UseCases.Payments.Queries.GetPaymentByIdQuery;
using E_Wallet.API.UseCases.Recharge.Commands.CreateRechargeCommand;
using E_Wallet.API.UseCases.Recharge.Commands.UpdateRechargeCommand;
using E_Wallet.API.UseCases.Recharge.Queries.GetRechargeByRechargeCodeQuery;
using E_Wallet.API.UseCases.Transactions.Commands.CreateTransactionCommand;
using E_Wallet.API.UseCases.Transactions.Queries.GetTransactionHistoryQuery;
using E_Wallet.API.UseCases.Users.Queries.GetCustomerByUserIdQuery;
using E_Wallet.API.UseCases.Wallets.Queries.CheckCustomerWalletQuery;
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
        ///Get My Transaction History 
        /// </summary>
        [HttpGet("{walletId}")]
        [Authorize(Roles = "Customer")]

        public async Task<IActionResult> GetMyTransactionHistory(int walletId)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new CheckUserWalletQuery() { ApplicationUserId = currentUserId, WalletId = walletId });
            if (!result) return BadRequest("The wallet you try get transactions history to it NOT FOR YOU!!");
            var response = await _mediator.Send(new GetTransactionHistoryQuery() { WalletId = walletId});
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
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
            var result = await _mediator.Send(new CheckUserWalletQuery() { ApplicationUserId = currentUserId, WalletId = dto.YourWalletId });
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
            var result = await _mediator.Send(new CheckUserWalletQuery() { ApplicationUserId = currentUserId, WalletId = dto.YourWalletId });
            if (!result) return BadRequest("The wallet you try pay money from it NOT FOR YOU!!");
            var response = await _mediator.Send(new CreateTransactionCommand() { WalletId = dto.YourWalletId, RecipientWalletId = dto.PaymentServiceWalletId, TransactionType = TransactionType.Payment, Amount = dto.Amount, Details = dto.Details });
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        /// <summary>
        ///Create Recharge Code - CUSTOMER ROLE
        /// </summary> 
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateMyRechargeCode([FromForm] CreateRechargeCommand command)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _mediator.Send(new CheckUserWalletQuery() { ApplicationUserId = currentUserId, WalletId = command.WalletId });
            if (!result) return BadRequest("You Try Recharge Wallet For Another One!!!!");
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        /// <summary>
        ///Make Recharge Transaction 
        /// </summary>
        /// <param name="rechargeCode">You must enter the ACTIVATE recharge code.</param>
        [HttpPost("{rechargeCode}")]
        [Authorize(Roles = "Customer")]

        public async Task<IActionResult> RechargeMyWallet(string rechargeCode)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var recharge = await _mediator.Send(new GetRechargeByCodeQuery() { RechargeCode = rechargeCode });
            if (recharge.Data.IsRecharged) return BadRequest("This recharge code exbired because you used it!!!");
            var result = await _mediator.Send(new CheckUserWalletQuery() { ApplicationUserId = currentUserId, WalletId = recharge.Data.WalletId });
            if (!result) return BadRequest("The wallet you try recharge it NOT FOR YOU!!");
            if (!recharge.IsSuccess) return BadRequest(recharge.Message);
            var response = await _mediator.Send(new CreateTransactionCommand() { WalletId = recharge.Data.RechargeWalletId, RecipientWalletId = recharge.Data.WalletId, TransactionType = TransactionType.Recharge, Amount = recharge.Data.Amount, Details = recharge.Data.Details });
            await _mediator.Send(new UpdateRechargeCommand() { RechargeCode = rechargeCode, isRecharged = true });
            if (response.IsSuccess)
            {

                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
