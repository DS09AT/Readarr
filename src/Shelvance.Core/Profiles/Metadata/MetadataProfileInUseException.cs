using System.Net;
using Shelvance.Core.Exceptions;

namespace Shelvance.Core.Profiles.Metadata
{
    public class MetadataProfileInUseException : ShelvanceClientException
    {
        public MetadataProfileInUseException(string name)
            : base(HttpStatusCode.BadRequest, "Metadata profile [{0}] is in use.", name)
        {
        }
    }
}
