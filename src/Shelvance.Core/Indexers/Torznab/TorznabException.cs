using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Indexers.Torznab
{
    public class TorznabException : ShelvanceException
    {
        public TorznabException(string message, params object[] args)
            : base(message, args)
        {
        }

        public TorznabException(string message)
            : base(message)
        {
        }
    }
}
