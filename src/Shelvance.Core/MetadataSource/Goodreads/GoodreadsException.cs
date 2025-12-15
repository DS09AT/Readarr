using System;
using System.Net;
using Shelvance.Core.Exceptions;

namespace Shelvance.Core.MetadataSource.Goodreads
{
    public class GoodreadsException : ShelvanceClientException
    {
        public GoodreadsException(string message)
            : base(HttpStatusCode.ServiceUnavailable, message)
        {
        }

        public GoodreadsException(string message, params object[] args)
            : base(HttpStatusCode.ServiceUnavailable, message, args)
        {
        }

        public GoodreadsException(string message, Exception innerException, params object[] args)
            : base(HttpStatusCode.ServiceUnavailable, message, innerException, args)
        {
        }
    }
}
