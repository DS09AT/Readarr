using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.MetadataSource
{
    public interface IMetadataProviderRepository : IProviderRepository<MetadataProviderDefinition>
    {
    }

    public class MetadataProviderRepository : ProviderRepository<MetadataProviderDefinition>, IMetadataProviderRepository
    {
        public MetadataProviderRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }
    }
}
