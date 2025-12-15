using Shelvance.Core.Notifications;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class FixFutureNotificationStatusTimes : FixFutureProviderStatusTimes<NotificationStatus>, IHousekeepingTask
    {
        public FixFutureNotificationStatusTimes(INotificationStatusRepository notificationStatusRepository)
            : base(notificationStatusRepository)
        {
        }
    }
}
