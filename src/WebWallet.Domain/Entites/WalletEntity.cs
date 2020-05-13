using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using WebWallet.Domain.Enums;

namespace WebWallet.Domain.Entites
{
    
    /// <summary>
    ///     Presents the essence of the wallet.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public class WalletEntity
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebWallet.Domain.Entites"/> class.
        /// </summary>
        /// <param name="balance">The balance of user.</param>
        /// <param name="currency">The currency of user.</param>
        /// <param name="userEntity">The currency of user.</param>
        public WalletEntity(decimal balance, Currency currency, UserEntity userEntity) : this()
        {
            SetBalance(balance);
            SetCurrency(currency);
            SetUserEntity(userEntity);
        }
        
        /// <summary>
        ///     Default values for creating a record in the database.
        /// </summary>
        private WalletEntity()
        {
            CreationHistory = DateTimeOffset.UtcNow;
        }

        /// <summary>
        ///     Gets the primary key.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        ///     Gets the balance of user.
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        ///     Sets the balance of user.
        /// </summary>
        /// <param name="balance">The balance of user.</param>
        public void SetBalance(decimal balance)
        {
            Balance = balance;
        }
        
        /// <summary>
        ///     Gets the currency of balance.
        /// </summary>
        public Currency Currency { get; private set; }

        /// <summary>
        ///     Sets the currency of balance.
        /// </summary>
        /// <param name="currency">The currency of balance.</param>
        /// <exception cref="InvalidEnumArgumentException">Thrown if currency is not exists.</exception>
        public void SetCurrency(Currency currency)
        {
            if (!Enum.IsDefined(typeof(Currency), currency))
                throw new InvalidEnumArgumentException(nameof(currency), (int) currency, typeof(Currency));

            Currency = currency;
        }
        
        /// <summary>
        ///     Gets system creation history time.
        /// </summary>
        /// <remarks>Created in Universal Coordinated Universal Time (UTC).</remarks>
        public DateTimeOffset CreationHistory { get; private set; }

        /// <summary>
        ///     Gets the primary key of user.
        /// </summary>
        public long UserEntityId { get; private set; }

        /// <summary>
        ///     Gets the essence of the user.
        /// </summary>
        public UserEntity UserEntity { get; private set; }

        /// <summary>
        ///     Sets the essence of the user.
        /// </summary>
        /// <param name="userEntity">The essence of the user.</param>
        public void SetUserEntity(UserEntity userEntity)
        {
            UserEntity = userEntity ?? throw new ArgumentNullException(paramName: nameof(userEntity));
            if (userEntity.Id >= 0) UserEntityId = userEntity.Id;
        }
    }
}