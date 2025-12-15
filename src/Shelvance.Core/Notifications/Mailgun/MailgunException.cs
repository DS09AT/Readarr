using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Mailgun
{
    public class MailgunException : ShelvanceException
    {
        public MailgunException(string message)
            : base(message)
        {
        }

        public MailgunException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
