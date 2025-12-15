using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.SendGrid
{
    public class SendGridException : ShelvanceException
    {
        public SendGridException(string message)
            : base(message)
        {
        }

        public SendGridException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
