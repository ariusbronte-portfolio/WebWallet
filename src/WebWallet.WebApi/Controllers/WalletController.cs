using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWallet.Application.DTOs;
using WebWallet.Application.Wallet.Commands.Convert;
using WebWallet.Application.Wallet.Commands.Deposit;
using WebWallet.Application.Wallet.Commands.Withdraw;
using WebWallet.Application.Wallet.Queries.Balance;

namespace WebWallet.WebApi.Controllers
{
    /// <summary>
    ///     The controller is responsible for working with wallet.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WalletController : ControllerBase
    {
        /// <summary>
        ///     Default mediator implementation.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebWallet.WebApi.Controllers.WalletController"/> class.
        /// </summary>
        /// <param name="mediator">Default mediator implementation.</param>
        public WalletController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        /// <summary>
        ///     Get the state of your wallet (the amount of money in each currency).
        /// </summary>
        /// <param name="userId">The primary user key.</param>
        /// <param name="cancellationToken">Client closed request.</param>
        /// <returns>The user's balance.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BalanceDto>>> Balance(
            long userId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Ok(await _mediator.Send(new BalanceQuery(userId), cancellationToken));
        }

        /// <summary>
        ///     Top up user wallet in one of the currencies.
        /// </summary>
        /// <param name="command">Request body.</param>
        /// <param name="cancellationToken">Client closed request.</param>
        /// <response code="200">If the wallet has been successfully replenished.</response>
        /// <response code="400">If the request body will not pass validation.</response>
        /// <response code="404">If the user is not found.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Deposit(
            [FromBody] DepositCommand command,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        
        /// <summary>
        ///     Withdraw money in one of the currencies.
        /// </summary>
        /// <param name="command">Request body.</param>
        /// <param name="cancellationToken">Client closed request.</param>
        /// <response code="200">If the money was successfully withdrawn.</response>
        /// <response code="400">If the request body will not pass validation.</response>
        /// <response code="404">If the user is not found.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Withdraw(
            [FromBody] WithdrawCommand command,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        ///     Transfer money from one currency to another.
        /// </summary>
        /// <param name="command">Request body.</param>
        /// <param name="cancellationToken">Client closed request.</param>
        /// <response code="200">If the currency was successfully converted to another currency.</response>
        /// <response code="400">If the request body will not pass validation.</response>
        /// <response code="404">If the user is not found.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BalanceDto>> Convert(
            [FromBody] ConvertCommand command,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}