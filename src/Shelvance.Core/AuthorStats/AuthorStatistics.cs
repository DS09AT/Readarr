using System.Collections.Generic;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.AuthorStats
{
    public class AuthorStatistics : ResultSet
    {
        public int AuthorId { get; set; }
        public int BookFileCount { get; set; }
        public int BookCount { get; set; }
        public int AvailableBookCount { get; set; }
        public int TotalBookCount { get; set; }
        public long SizeOnDisk { get; set; }
        public List<BookStatistics> BookStatistics { get; set; }
    }
}
