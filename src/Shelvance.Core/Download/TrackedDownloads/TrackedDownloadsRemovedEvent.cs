using System.Collections.Generic;
using Shelvance.Common.Messaging;

namespace Shelvance.Core.Download.TrackedDownloads
{
    public class TrackedDownloadsRemovedEvent : IEvent
    {
        public List<TrackedDownload> TrackedDownloads { get; private set; }

        public TrackedDownloadsRemovedEvent(List<TrackedDownload> trackedDownloads)
        {
            TrackedDownloads = trackedDownloads;
        }
    }
}
