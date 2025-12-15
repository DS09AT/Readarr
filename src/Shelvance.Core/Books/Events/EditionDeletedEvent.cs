using Shelvance.Common.Messaging;

namespace Shelvance.Core.Books.Events
{
    public class EditionDeletedEvent : IEvent
    {
        public Edition Edition { get; private set; }

        public EditionDeletedEvent(Edition edition)
        {
            Edition = edition;
        }
    }
}
