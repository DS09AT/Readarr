using Shelvance.Common.Messaging;

namespace Shelvance.Core.ThingiProvider.Events
{
    public class ProviderAddedEvent<TProvider> : IEvent
    {
        public ProviderDefinition Definition { get; private set; }

        public ProviderAddedEvent(ProviderDefinition definition)
        {
            Definition = definition;
        }
    }
}
