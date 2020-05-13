using System.Diagnostics.CodeAnalysis;

// The number of currencies is deliberately reduced.
namespace WebWallet.Domain.Enums
{
    /// <summary>
    ///     The codes and qualifiers of the currency.
    /// </summary>
    /// <remarks>ISO-4217</remarks>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum Currency
    {
        /// <summary>
        ///     US Dollar.
        /// </summary>
        USD = 840,
        
        /// <summary>
        ///     Yen.
        /// </summary>
        JPY = 392,
        
        /// <summary>
        ///     Bulgarian Lev.
        /// </summary>
        BGN = 975,
        
        /// <summary>
        ///     Czech Koruna.
        /// </summary>
        CZK = 203,
        
        /// <summary>
        ///     Danish Krone.
        /// </summary>
        DKK = 208,

        /// <summary>
        ///     Russian Ruble.
        /// </summary>
        RUB = 643,
        
        /// <summary>
        ///     Turkish Lira.
        /// </summary>
        TRY = 949,
        
        /// <summary>
        ///     Rand.
        /// </summary>
        ZAR = 710,
    }
}