using Shelvance.Core.Parser.Model;
using Shelvance.Core.ThingiProvider.Status;

namespace Shelvance.Core.Indexers
{
    public class IndexerStatus : ProviderStatusBase
    {
        public ReleaseInfo LastRssSyncReleaseInfo { get; set; }
    }
}
