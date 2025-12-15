using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Profiles.Releases
{
    public interface IRestrictionRepository : IBasicRepository<ReleaseProfile>
    {
    }

    public class ReleaseProfileRepository : BasicRepository<ReleaseProfile>, IRestrictionRepository
    {
        public ReleaseProfileRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }
    }
}
