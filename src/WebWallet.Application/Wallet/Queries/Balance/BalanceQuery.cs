using System.Collections.Generic;
using MediatR;
using WebWallet.Application.DTOs;

namespace WebWallet.Application.Wallet.Queries.Balance
{
    public class BalanceQuery : IRequest<IEnumerable<BalanceDto>>
    {
        public BalanceQuery(long userId)
        {
            UserId = userId;
        }
        
        /// <summary>
        ///     The primary user key.
        /// </summary>
        public long UserId { get; }
    }
}