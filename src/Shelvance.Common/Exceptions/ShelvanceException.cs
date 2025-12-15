using System;

namespace Shelvance.Common.Exceptions
{
    public abstract class ShelvanceException : ApplicationException
    {
        protected ShelvanceException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }

        protected ShelvanceException(string message)
            : base(message)
        {
        }

        protected ShelvanceException(string message, Exception innerException, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }

        protected ShelvanceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
