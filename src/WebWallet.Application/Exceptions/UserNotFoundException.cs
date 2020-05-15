using System;

namespace WebWallet.Application.Exceptions
{
    [Serializable]
    public class UserNotFoundException : NotFoundException
    {
        /// <inheritdoc />
        public UserNotFoundException(string message) : base(message)
        {
        }
        
        /// <inheritdoc />
        public UserNotFoundException(string entity, object key) : base(entity, key)
        {
        }
    }
}