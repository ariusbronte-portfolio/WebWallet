using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebWallet.Application.Exceptions;
using WebWallet.DataAccess;
using WebWallet.Domain.Entites;
using WebWallet.Domain.Enums;

namespace WebWallet.Application.Wallet.Commands.Deposit
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, Unit>
    {
        private readonly WebWalletDbContext _dbContext;

        public DepositCommandHandler(WebWalletDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Unit> Handle(DepositCommand request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userId = request.UserId;
            var balance = request.Balance;
            var currency = request.Currency;

            var user = await GetUserAsync(userId, cancellationToken);
            if (user == null)
            {
                throw new UserNotFoundException(nameof(UserEntity), userId);
            }

            var wallet = await GetWalletAsync(userId, currency, cancellationToken);
            if (wallet == null)
            {
                var entity = new WalletEntity(balance, currency, user);
                await AddWalletAsync(entity, cancellationToken);

                return Unit.Value;
            }

            wallet.AddBalance(balance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<UserEntity> GetUserAsync(long userId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
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

        private async Task AddWalletAsync(WalletEntity entity, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _dbContext.Wallets.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}