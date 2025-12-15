using System.Collections.Generic;
using Shelvance.Common.Messaging;
using Shelvance.Core.Download.TrackedDownloads;
using Shelvance.Core.Qualities;

namespace Shelvance.Core.Download
{
    public class DownloadIgnoredEvent : IEvent
    {
        public int AuthorId { get; set; }
        public List<int> BookIds { get; set; }
        public QualityModel Quality { get; set; }
        public string SourceTitle { get; set; }
        public DownloadClientItemClientInfo DownloadClientInfo { get; set; }
        public string DownloadId { get; set; }
        public string Message { get; set; }
        public TrackedDownload TrackedDownload { get; set; }
    }
}
