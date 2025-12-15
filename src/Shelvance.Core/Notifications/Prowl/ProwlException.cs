using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Prowl
{
    public class ProwlException : ShelvanceException
    {
        public ProwlException(string message)
            : base(message)
        {
        }

        public ProwlException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
