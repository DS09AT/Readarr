using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Parser
{
    public class InvalidDateException : ShelvanceException
    {
        public InvalidDateException(string message, params object[] args)
            : base(message, args)
        {
        }

        public InvalidDateException(string message)
            : base(message)
        {
        }
    }
}
