using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Organizer
{
    public interface INamingConfigRepository : IBasicRepository<NamingConfig>
    {
    }

    public class NamingConfigRepository : BasicRepository<NamingConfig>, INamingConfigRepository
    {
        public NamingConfigRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }
    }
}
