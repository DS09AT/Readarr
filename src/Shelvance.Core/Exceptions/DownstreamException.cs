using System.Net;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Exceptions
{
    public class DownstreamException : ShelvanceException
    {
        public HttpStatusCode StatusCode { get; private set; }

        public DownstreamException(HttpStatusCode statusCode, string message, params object[] args)
            : base(message, args)
        {
            StatusCode = statusCode;
        }

        public DownstreamException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
