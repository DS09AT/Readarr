using System.Collections.Generic;

namespace Shelvance.Core.Download.Clients.UTorrent
{
    public class UTorrentTorrentCache
    {
        public string CacheID { get; set; }

        public List<UTorrentTorrent> Torrents { get; set; }
    }
}
