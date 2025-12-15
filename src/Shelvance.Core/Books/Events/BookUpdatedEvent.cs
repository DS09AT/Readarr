using Shelvance.Common.Messaging;

namespace Shelvance.Core.Books.Events
{
    public class BookUpdatedEvent : IEvent
    {
        public Book Book { get; private set; }

        public BookUpdatedEvent(Book book)
        {
            Book = book;
        }
    }
}
