using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Apprise
{
    public class AppriseException : ShelvanceException
    {
        public AppriseException(string message)
            : base(message)
        {
        }

        public AppriseException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
