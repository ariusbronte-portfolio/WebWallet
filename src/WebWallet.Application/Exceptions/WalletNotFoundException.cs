using System;

namespace WebWallet.Application.Exceptions
{
    [Serializable]
    public class WalletNotFoundException : NotFoundException
    {
        /// <inheritdoc />
        public WalletNotFoundException(string message) : base(message)
        {
        }
        
        /// <inheritdoc />
        public WalletNotFoundException(string entity, object key) : base(entity, key)
        {
        }
    }
}