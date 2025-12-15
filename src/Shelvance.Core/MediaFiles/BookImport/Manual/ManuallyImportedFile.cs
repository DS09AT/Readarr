using Shelvance.Core.Download.TrackedDownloads;

namespace Shelvance.Core.MediaFiles.BookImport.Manual
{
    public class ManuallyImportedFile
    {
        public TrackedDownload TrackedDownload { get; set; }
        public ImportResult ImportResult { get; set; }
    }
}
