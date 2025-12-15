using System.Collections.Generic;
using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Download.Pending
{
    public interface IPendingReleaseRepository : IBasicRepository<PendingRelease>
    {
        void DeleteByAuthorId(int authorId);
        List<PendingRelease> AllByAuthorId(int authorId);
        List<PendingRelease> WithoutFallback();
    }

    public class PendingReleaseRepository : BasicRepository<PendingRelease>, IPendingReleaseRepository
    {
        public PendingReleaseRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }

        public void DeleteByAuthorId(int authorId)
        {
            Delete(x => x.AuthorId == authorId);
        }

        public List<PendingRelease> AllByAuthorId(int authorId)
        {
            return Query(p => p.AuthorId == authorId);
        }

        public List<PendingRelease> WithoutFallback()
        {
            return Query(p => p.Reason != PendingReleaseReason.Fallback);
        }
    }
}
