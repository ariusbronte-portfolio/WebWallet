using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebWallet.Application.Exceptions;
using WebWallet.DataAccess;
using WebWallet.Domain.Entites;
using WebWallet.Domain.Enums;

namespace WebWallet.Application.Wallet.Commands.Withdraw
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, Unit>
    {
        private readonly WebWalletDbContext _dbContext;

        public WithdrawCommandHandler(WebWalletDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Unit> Handle(WithdrawCommand request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userId = request.UserId;
            var withdraw = request.Withdraw;
            var currency = request.Currency;

            var userExists = await UserAnyAsync(userId, cancellationToken);
            if (!userExists)
            {
                throw new UserNotFoundException(nameof(UserEntity), userId);
            }

            var wallet = await GetWalletAsync(userId, currency, cancellationToken);
            if (wallet == null)
            {
                throw new WalletNotFoundException(nameof(WalletEntity), $"{nameof(currency)}: {currency}");
            }

            if (wallet.Balance < withdraw)
            {
                throw new BalanceNotEnoughException();
            }

            wallet.SubtractBalance(withdraw);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<bool> UserAnyAsync(long userId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Users
                .AsNoTracking()
                .AnyAsync(x => x.Id == userId, cancellationToken);
        }

        private async Task<WalletEntity> GetWalletAsync(
            long userId,
            Currency currency,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Wallets
                .FirstOrDefaultAsync(x =>
                    x.UserEntityId == userId && x.Currency == currency, cancellationToken);
        }
    }
}