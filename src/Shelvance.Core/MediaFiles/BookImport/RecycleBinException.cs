using System;
using System.IO;

namespace Shelvance.Core.MediaFiles.BookImport
{
    public class RecycleBinException : DirectoryNotFoundException
    {
        public RecycleBinException()
        {
        }

        public RecycleBinException(string message)
            : base(message)
        {
        }

        public RecycleBinException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
