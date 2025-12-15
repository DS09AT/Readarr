using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Webhook
{
    public class WebhookException : ShelvanceException
    {
        public WebhookException(string message)
            : base(message)
        {
        }

        public WebhookException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
