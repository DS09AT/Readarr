using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Host.AccessControl
{
    public class RemoteAccessException : ShelvanceException
    {
        public RemoteAccessException(string message, params object[] args)
            : base(message, args)
        {
        }

        public RemoteAccessException(string message)
            : base(message)
        {
        }

        public RemoteAccessException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }

        public RemoteAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
