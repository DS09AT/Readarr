using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Gotify
{
    public class GotifyException : ShelvanceException
    {
        public GotifyException(string message)
            : base(message)
        {
        }

        public GotifyException(string message, params object[] args)
            : base(message, args)
        {
        }

        public GotifyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
