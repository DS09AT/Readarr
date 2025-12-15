using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Configuration
{
    public class AccessDeniedConfigFileException : ShelvanceException
    {
        public AccessDeniedConfigFileException(string message)
            : base(message)
        {
        }

        public AccessDeniedConfigFileException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
