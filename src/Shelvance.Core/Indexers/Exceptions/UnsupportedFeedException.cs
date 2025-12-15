using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Indexers.Exceptions
{
    public class UnsupportedFeedException : ShelvanceException
    {
        public UnsupportedFeedException(string message, params object[] args)
            : base(message, args)
        {
        }

        public UnsupportedFeedException(string message)
            : base(message)
        {
        }
    }
}
