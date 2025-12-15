using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Configuration
{
    public class InvalidConfigFileException : ShelvanceException
    {
        public InvalidConfigFileException(string message)
            : base(message)
        {
        }

        public InvalidConfigFileException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
