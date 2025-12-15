using System.Net;
using Shelvance.Core.Exceptions;

namespace Shelvance.Core.Backup
{
    public class RestoreBackupFailedException : ShelvanceClientException
    {
        public RestoreBackupFailedException(HttpStatusCode statusCode, string message, params object[] args)
            : base(statusCode, message, args)
        {
        }

        public RestoreBackupFailedException(HttpStatusCode statusCode, string message)
            : base(statusCode, message)
        {
        }
    }
}
