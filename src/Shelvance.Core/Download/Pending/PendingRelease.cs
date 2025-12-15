using System;
using Shelvance.Core.Datastore;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.Download.Pending
{
    public class PendingRelease : ModelBase
    {
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime Added { get; set; }
        public ParsedBookInfo ParsedBookInfo { get; set; }
        public ReleaseInfo Release { get; set; }
        public PendingReleaseReason Reason { get; set; }
        public PendingReleaseAdditionalInfo AdditionalInfo { get; set; }

        //Not persisted
        public RemoteBook RemoteBook { get; set; }
    }

    public class PendingReleaseAdditionalInfo
    {
        public ReleaseSourceType ReleaseSource { get; set; }
    }
}
