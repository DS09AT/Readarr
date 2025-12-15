using Shelvance.Core.MediaFiles.BookImport;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.MediaFiles.Commands
{
    public class DownloadedBooksScanCommand : Command
    {
        // Properties used by third-party apps, do not modify.
        public string Path { get; set; }
        public string DownloadClientId { get; set; }
        public ImportMode ImportMode { get; set; }
    }
}
