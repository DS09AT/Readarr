using System;
using System.Collections.Generic;
using Shelvance.Core.Books;
using Shelvance.Core.Datastore;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Qualities;

namespace Shelvance.Core.Blocklisting
{
    public class Blocklist : ModelBase
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<int> BookIds { get; set; }
        public string SourceTitle { get; set; }
        public QualityModel Quality { get; set; }
        public DateTime Date { get; set; }
        public DateTime? PublishedDate { get; set; }
        public long? Size { get; set; }
        public DownloadProtocol Protocol { get; set; }
        public string Indexer { get; set; }
        public IndexerFlags IndexerFlags { get; set; }
        public string Message { get; set; }
        public string TorrentInfoHash { get; set; }
    }
}
