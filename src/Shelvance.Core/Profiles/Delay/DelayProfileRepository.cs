using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Profiles.Delay
{
    public interface IDelayProfileRepository : IBasicRepository<DelayProfile>
    {
    }

    public class DelayProfileRepository : BasicRepository<DelayProfile>, IDelayProfileRepository
    {
        public DelayProfileRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }
    }
}
