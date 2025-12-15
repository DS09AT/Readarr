using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Join
{
    public class JoinException : ShelvanceException
    {
        public JoinException(string message)
            : base(message)
        {
        }

        public JoinException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
