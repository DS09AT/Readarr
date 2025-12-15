using System;
using System.Net;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Exceptions
{
    public class ShelvanceClientException : ShelvanceException
    {
        public HttpStatusCode StatusCode { get; private set; }

        public ShelvanceClientException(HttpStatusCode statusCode, string message, params object[] args)
            : base(message, args)
        {
            StatusCode = statusCode;
        }

        public ShelvanceClientException(HttpStatusCode statusCode, string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
            StatusCode = statusCode;
        }

        public ShelvanceClientException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
