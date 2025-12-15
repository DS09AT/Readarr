using Shelvance.Core.Indexers;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.Download
{
    public class DownloadClientDefinition : ProviderDefinition
    {
        public DownloadProtocol Protocol { get; set; }
        public int Priority { get; set; } = 1;

        public bool RemoveCompletedDownloads { get; set; } = true;
        public bool RemoveFailedDownloads { get; set; } = true;
    }
}
