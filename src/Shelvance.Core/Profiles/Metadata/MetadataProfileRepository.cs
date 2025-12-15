using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Profiles.Metadata
{
    public interface IMetadataProfileRepository : IBasicRepository<MetadataProfile>
    {
        bool Exists(int id);
    }

    public class MetadataProfileRepository : BasicRepository<MetadataProfile>, IMetadataProfileRepository
    {
        public MetadataProfileRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }

        public bool Exists(int id)
        {
            return Query(p => p.Id == id).Count == 1;
        }
    }
}
