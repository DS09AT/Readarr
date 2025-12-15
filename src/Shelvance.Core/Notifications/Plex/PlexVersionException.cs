using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Plex
{
    public class PlexVersionException : ShelvanceException
    {
        public PlexVersionException(string message)
            : base(message)
        {
        }

        public PlexVersionException(string message, params object[] args)
            : base(message, args)
        {
        }
    }
}
