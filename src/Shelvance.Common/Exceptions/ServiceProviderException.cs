using System;

namespace Shelvance.Common.Exceptions
{
    public class ServiceProviderException : ShelvanceException
    {
        public ServiceProviderException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }

        public ServiceProviderException(string message)
            : base(message)
        {
        }

        public ServiceProviderException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }

        public ServiceProviderException(Exception innerException, string message)
            : base(message, innerException)
        {
        }
    }
}
