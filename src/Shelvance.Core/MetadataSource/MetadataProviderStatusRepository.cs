using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;
using Shelvance.Core.ThingiProvider.Status;

namespace Shelvance.Core.MetadataSource
{
    public interface IMetadataProviderStatusRepository : IProviderStatusRepository<MetadataProviderStatus>
    {
    }

    public class MetadataProviderStatusRepository : ProviderStatusRepository<MetadataProviderStatus>, IMetadataProviderStatusRepository
    {
        public MetadataProviderStatusRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }
    }
}
