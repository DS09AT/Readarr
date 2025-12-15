using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.Indexers
{
    public interface IIndexerSettings : IProviderConfig
    {
        string BaseUrl { get; set; }
        int? EarlyReleaseLimit { get; set; }
    }
}
