using System;

namespace WebWallet.Application.Exceptions
{
    [Serializable]
    public partial class NotFoundException : Exception
    {
        /// <inheritdoc />
        public NotFoundException(string message) : base(message)
        {
        }
        
        /// <inheritdoc />
        public NotFoundException(string entity, object key)
        {
            Message = $"Entity '{entity}' does not matter with the '{key}' key.";
        }
        
        /// <inheritdoc />
        public override string Message { get; }
    }
}