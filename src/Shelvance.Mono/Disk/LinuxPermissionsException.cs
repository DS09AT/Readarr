using Shelvance.Common.Exceptions;

namespace Shelvance.Mono.Disk
{
    public class LinuxPermissionsException : ShelvanceException
    {
        public LinuxPermissionsException(string message, params object[] args)
            : base(message, args)
        {
        }

        public LinuxPermissionsException(string message)
            : base(message)
        {
        }
    }
}
