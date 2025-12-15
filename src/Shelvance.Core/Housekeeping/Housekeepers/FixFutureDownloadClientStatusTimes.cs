using Shelvance.Core.Download;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class FixFutureDownloadClientStatusTimes : FixFutureProviderStatusTimes<DownloadClientStatus>, IHousekeepingTask
    {
        public FixFutureDownloadClientStatusTimes(IDownloadClientStatusRepository downloadClientStatusRepository)
            : base(downloadClientStatusRepository)
        {
        }
    }
}
