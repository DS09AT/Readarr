using Shelvance.Common.Messaging;

namespace Shelvance.Core.ThingiProvider.Events
{
    public class ProviderUpdatedEvent<TProvider> : IEvent
    {
        public ProviderDefinition Definition { get; private set; }

        public ProviderUpdatedEvent(ProviderDefinition definition)
        {
            Definition = definition;
        }
    }
}
