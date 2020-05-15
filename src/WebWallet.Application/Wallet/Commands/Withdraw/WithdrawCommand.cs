using MediatR;
using WebWallet.Domain.Enums;

namespace WebWallet.Application.Wallet.Commands.Withdraw
{
    public class WithdrawCommand : IRequest<Unit>
    {
        /// <summary>
        ///     The primary user key.
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        ///     The amount you need to cash out.
        /// </summary>
        public decimal Withdraw { get; set; }
        
        /// <summary>
        ///     The currency that the amount will be cashed from.
        /// </summary>
        public Currency Currency { get; set; } 
    }
}