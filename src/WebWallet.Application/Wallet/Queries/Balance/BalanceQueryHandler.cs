using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebWallet.Application.DTOs;
using WebWallet.DataAccess;

namespace WebWallet.Application.Wallet.Queries.Balance
{
    public class BalanceQueryHandler : IRequestHandler<BalanceQuery, IEnumerable<BalanceDto>>
    {
        private readonly WebWalletDbContext _dbContext;

        public BalanceQueryHandler(WebWalletDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<BalanceDto>> Handle(BalanceQuery request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userId = request.UserId;

            return await _dbContext.Wallets
                .AsNoTracking()
                .Where(x => x.UserEntityId == userId)
                .Select(x => new BalanceDto
                {
                    Balance = x.Balance,
                    Currency = x.Currency
                }).ToArrayAsync(cancellationToken);
        }
    }
}