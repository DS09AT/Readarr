using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Discord
{
    public class DiscordException : ShelvanceException
    {
        public DiscordException(string message)
            : base(message)
        {
        }

        public DiscordException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
