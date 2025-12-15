using Shelvance.Common.Messaging;

namespace Shelvance.Core.Messaging.Events
{
    public interface IEventAggregator
    {
        void PublishEvent<TEvent>(TEvent @event)
            where TEvent : class, IEvent;
    }
}
