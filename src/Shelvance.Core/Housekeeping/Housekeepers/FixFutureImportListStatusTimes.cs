using Shelvance.Core.ImportLists;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class FixFutureImportListStatusTimes : FixFutureProviderStatusTimes<ImportListStatus>, IHousekeepingTask
    {
        public FixFutureImportListStatusTimes(IImportListStatusRepository importListStatusRepository)
            : base(importListStatusRepository)
        {
        }
    }
}
