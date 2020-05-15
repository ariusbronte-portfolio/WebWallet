using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebWallet.Application.DTOs;
using WebWallet.Application.Exceptions;
using WebWallet.DataAccess;
using WebWallet.Domain.Entites;
using WebWallet.Domain.Enums;
using WebWallet.Infrastructure.Abstractions;
using WebWallet.Infrastructure.Extensions;

namespace WebWallet.Application.Wallet.Commands.Convert
{
    public class ConvertCommandHandler : IRequestHandler<ConvertCommand, BalanceDto>
    {
        private readonly WebWalletDbContext _dbContext;
        private readonly IEcuEuropa _ecuEuropa;

        public ConvertCommandHandler(WebWalletDbContext dbContext, IEcuEuropa ecuEuropa)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _ecuEuropa = ecuEuropa ?? throw new ArgumentNullException(nameof(ecuEuropa));
        }

        public async Task<BalanceDto> Handle(ConvertCommand request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var userId = request.UserId;
            var fromCurrency = request.FromCurrency;
            var toCurrency = request.ToCurrency;

            var userExists = await UserAnyAsync(userId, cancellationToken);
            if (!userExists)
            {
                throw new UserNotFoundException(nameof(UserEntity), userId);
            }

            var wallet = await GetWalletAsync(userId, fromCurrency, cancellationToken);
            if (wallet == null)
            {
                throw new WalletNotFoundException(nameof(WalletEntity), $"{nameof(fromCurrency)}: {fromCurrency}");
            }

            var envelope = await _ecuEuropa.GetEnvelope();
            var fromRate = envelope.GetRate(x => (int) x.Currency == (int) fromCurrency);
            var toRate = envelope.GetRate(x => (int) x.Currency == (int) toCurrency);
            var balance = wallet.Balance;
            
            // [converted amount] = [balance] * [rate(1)] / [rate(2)]
            var amount = balance * toRate / fromRate;
            
            wallet.SetBalance(amount);
            wallet.SetCurrency(toCurrency);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new BalanceDto
            {
                Balance = amount,
                Currency = toCurrency
            };
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