using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.ImportLists.Goodreads
{
    public class GoodreadsException : ShelvanceException
    {
        public GoodreadsException(string message)
            : base(message)
        {
        }

        public GoodreadsException(string message, params object[] args)
            : base(message, args)
        {
        }

        public GoodreadsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class GoodreadsAuthorizationException : GoodreadsException
    {
        public GoodreadsAuthorizationException(string message)
            : base(message)
        {
        }
    }
}
