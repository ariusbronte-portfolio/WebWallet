using System;
using System.Runtime.Serialization;

namespace WebWallet.Application.Exceptions
{
    [Serializable]
    public class BalanceNotEnoughException : Exception
    {
        /// <inheritdoc />
        public BalanceNotEnoughException()
        {
            Message = "Not enough money to cash out";
        }

        /// <inheritdoc />
        public BalanceNotEnoughException(string message) : base(message)
        {
        }
        
        /// <inheritdoc />
        public BalanceNotEnoughException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <inheritdoc />
        protected BalanceNotEnoughException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        /// <inheritdoc />
        public override string Message { get; }
    }
}