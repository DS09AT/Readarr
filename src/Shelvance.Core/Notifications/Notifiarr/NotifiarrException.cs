using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Notifiarr
{
    public class NotifiarrException : ShelvanceException
    {
        public NotifiarrException(string message)
            : base(message)
        {
        }

        public NotifiarrException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
