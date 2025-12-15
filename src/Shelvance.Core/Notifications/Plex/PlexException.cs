using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Plex
{
    public class PlexException : ShelvanceException
    {
        public PlexException(string message)
            : base(message)
        {
        }

        public PlexException(string message, params object[] args)
            : base(message, args)
        {
        }

        public PlexException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
