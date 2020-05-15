using MediatR;
using WebWallet.Domain.Enums;

namespace WebWallet.Application.Wallet.Commands.Deposit
{
    public class DepositCommand : IRequest<Unit>
    {
        /// <summary>
        ///     The primary user key.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        ///     Amount to be deposited.
        /// </summary>
        public decimal Balance { get; set; }
        
        /// <summary>
        ///     The currency that the amount will be deposited in.
        /// </summary>
        public Currency Currency { get; set; } 
    }
}