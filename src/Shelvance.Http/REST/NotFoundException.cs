using System.Net;
using Shelvance.Http.Exceptions;

namespace Shelvance.Http.REST
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(object content = null)
            : base(HttpStatusCode.NotFound, content)
        {
        }
    }
}
