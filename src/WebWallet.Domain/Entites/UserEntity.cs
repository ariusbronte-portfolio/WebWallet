using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebWallet.Domain.Entites
{
    /// <summary>
    ///     Presents the essence of the user.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class UserEntity
    {
        private readonly ICollection<WalletEntity> _wallets = new HashSet<WalletEntity>();

        /// <summary>
        ///     Default values for creating a record in the database.
        /// </summary>
        public UserEntity()
        {
            CreationHistory = DateTimeOffset.UtcNow;
        }
        
        /// <summary>
        ///     Gets the primary key.
        /// </summary>
        public long Id { get; private set; }
        
        /// <summary>
        ///     Gets system creation history time.
        /// </summary>
        /// <remarks>Created in Universal Coordinated Universal Time (UTC).</remarks>
        public DateTimeOffset CreationHistory { get; private set; }

        /// <summary>
        ///     Presents the essence of the wallet.
        /// </summary>
        public IEnumerable<WalletEntity> Wallets => _wallets;
    }
}