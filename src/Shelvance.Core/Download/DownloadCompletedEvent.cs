using Shelvance.Common.Messaging;
using Shelvance.Core.Download.TrackedDownloads;

namespace Shelvance.Core.Download
{
    public class DownloadCompletedEvent : IEvent
    {
        public TrackedDownload TrackedDownload { get; private set; }
        public int AuthorId { get; set; }

        public DownloadCompletedEvent(TrackedDownload trackedDownload, int authorId)
        {
            TrackedDownload = trackedDownload;
            AuthorId = authorId;
        }
    }
}
