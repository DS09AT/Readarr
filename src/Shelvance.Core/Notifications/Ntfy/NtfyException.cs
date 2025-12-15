using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Ntfy
{
    public class NtfyException : ShelvanceException
    {
        public NtfyException(string message)
            : base(message)
        {
        }

        public NtfyException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
