using Shelvance.Core.Datastore;
using Shelvance.Core.Messaging.Events;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.Notifications
{
    public interface INotificationRepository : IProviderRepository<NotificationDefinition>
    {
    }

    public class NotificationRepository : ProviderRepository<NotificationDefinition>, INotificationRepository
    {
        public NotificationRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }
    }
}
