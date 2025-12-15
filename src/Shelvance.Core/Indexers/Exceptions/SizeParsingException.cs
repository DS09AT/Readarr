using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Indexers.Exceptions
{
    public class SizeParsingException : ShelvanceException
    {
        public SizeParsingException(string message, params object[] args)
            : base(message, args)
        {
        }
    }
}
