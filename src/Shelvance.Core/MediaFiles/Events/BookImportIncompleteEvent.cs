using Shelvance.Common.Messaging;
using Shelvance.Core.Download.TrackedDownloads;

namespace Shelvance.Core.MediaFiles.Events
{
    public class BookImportIncompleteEvent : IEvent
    {
        public TrackedDownload TrackedDownload { get; private set; }

        public BookImportIncompleteEvent(TrackedDownload trackedDownload)
        {
            TrackedDownload = trackedDownload;
        }
    }
}
