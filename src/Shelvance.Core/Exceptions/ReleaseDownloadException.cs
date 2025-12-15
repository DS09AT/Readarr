using System;
using Shelvance.Common.Exceptions;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.Exceptions
{
    public class ReleaseDownloadException : ShelvanceException
    {
        public ReleaseInfo Release { get; set; }

        public ReleaseDownloadException(ReleaseInfo release, string message, params object[] args)
            : base(message, args)
        {
            Release = release;
        }

        public ReleaseDownloadException(ReleaseInfo release, string message)
            : base(message)
        {
            Release = release;
        }

        public ReleaseDownloadException(ReleaseInfo release, string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
            Release = release;
        }

        public ReleaseDownloadException(ReleaseInfo release, string message, Exception innerException)
            : base(message, innerException)
        {
            Release = release;
        }
    }
}
