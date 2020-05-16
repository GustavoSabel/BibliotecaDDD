using System;

namespace Biblioteca.Domain.Common
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message)
        {
        }
    }
}
