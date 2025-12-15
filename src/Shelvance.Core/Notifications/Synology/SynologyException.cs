using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Synology
{
    public class SynologyException : ShelvanceException
    {
        public SynologyException(string message)
            : base(message)
        {
        }

        public SynologyException(string message, params object[] args)
            : base(message, args)
        {
        }
    }
}
