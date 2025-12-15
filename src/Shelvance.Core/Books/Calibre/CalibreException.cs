using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Books.Calibre
{
    public class CalibreException : ShelvanceException
    {
        public CalibreException(string message)
            : base(message)
        {
        }

        public CalibreException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
