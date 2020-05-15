using MediatR;
using WebWallet.Application.DTOs;
using WebWallet.Domain.Enums;

namespace WebWallet.Application.Wallet.Commands.Convert
{
    public class ConvertCommand : IRequest<BalanceDto>
    {
        /// <summary>
        ///     The primary user key.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        ///     The currency that will be converted to another currency.
        /// </summary>
        public Currency FromCurrency { get; set; }

        /// <summary>
        ///     The currency that will be converted to another currency.
        /// </summary>
        public Currency ToCurrency { get; set; }
    }
}