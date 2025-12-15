using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Subsonic
{
    public class SubsonicException : ShelvanceException
    {
        public SubsonicException(string message)
            : base(message)
        {
        }

        public SubsonicException(string message, params object[] args)
            : base(message, args)
        {
        }
    }
}
