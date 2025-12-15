using System.Collections.Generic;
using Shelvance.Common.Messaging;
using Shelvance.Core.Download;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.MediaFiles.Events
{
    public class TrackImportedEvent : IEvent
    {
        public LocalBook BookInfo { get; private set; }
        public BookFile ImportedBook { get; private set; }
        public List<BookFile> OldFiles { get; private set; }
        public bool NewDownload { get; private set; }
        public DownloadClientItemClientInfo DownloadClientInfo { get; set; }
        public string DownloadId { get; private set; }

        public TrackImportedEvent(LocalBook bookInfo, BookFile importedBook, List<BookFile> oldFiles, bool newDownload, DownloadClientItem downloadClientItem)
        {
            BookInfo = bookInfo;
            ImportedBook = importedBook;
            OldFiles = oldFiles;
            NewDownload = newDownload;

            if (downloadClientItem != null)
            {
                DownloadClientInfo = downloadClientItem.DownloadClientInfo;
                DownloadId = downloadClientItem.DownloadId;
            }
        }
    }
}
