using Shelvance.Common.Exceptions;

namespace Shelvance.Common.Disk
{
    public class NotParentException : ShelvanceException
    {
        public NotParentException(string message, params object[] args)
            : base(message, args)
        {
        }

        public NotParentException(string message)
            : base(message)
        {
        }
    }
}
