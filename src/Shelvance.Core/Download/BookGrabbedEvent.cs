using Shelvance.Common.Messaging;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.Download
{
    public class BookGrabbedEvent : IEvent
    {
        public RemoteBook Book { get; private set; }
        public int DownloadClientId { get; set; }
        public string DownloadClient { get; set; }
        public string DownloadClientName { get; set; }
        public string DownloadId { get; set; }

        public BookGrabbedEvent(RemoteBook book)
        {
            Book = book;
        }
    }
}
