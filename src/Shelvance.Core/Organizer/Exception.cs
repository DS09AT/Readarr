using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Organizer
{
    public class NamingFormatException : ShelvanceException
    {
        public NamingFormatException(string message, params object[] args)
            : base(message, args)
        {
        }

        public NamingFormatException(string message)
            : base(message)
        {
        }
    }
}
