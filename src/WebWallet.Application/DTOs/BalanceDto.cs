using WebWallet.Domain.Enums;

namespace WebWallet.Application.DTOs
{
    /// <summary>
    ///     The user's balance info.
    /// </summary>
    public class BalanceDto
    {
        /// <summary>
        ///     The user's balance.
        /// </summary>
        public decimal Balance { get; set; }
        
        /// <summary>
        ///     The balance currency.
        /// </summary>
        public Currency Currency { get; set; }
    }
}