using Shelvance.Core.Indexers;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class FixFutureIndexerStatusTimes : FixFutureProviderStatusTimes<IndexerStatus>, IHousekeepingTask
    {
        public FixFutureIndexerStatusTimes(IIndexerStatusRepository indexerStatusRepository)
            : base(indexerStatusRepository)
        {
        }
    }
}
