using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Indexers.Exceptions
{
    public class ApiKeyException : ShelvanceException
    {
        public ApiKeyException(string message, params object[] args)
            : base(message, args)
        {
        }

        public ApiKeyException(string message)
            : base(message)
        {
        }
    }
}
