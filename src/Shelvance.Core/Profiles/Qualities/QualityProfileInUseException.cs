using System.Net;
using Shelvance.Core.Exceptions;

namespace Shelvance.Core.Profiles.Qualities
{
    public class QualityProfileInUseException : ShelvanceClientException
    {
        public QualityProfileInUseException(string name)
            : base(HttpStatusCode.BadRequest, "Profile [{0}] is in use.", name)
        {
        }
    }
}
