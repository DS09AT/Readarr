using Shelvance.Common.Messaging;
using Shelvance.Core.Books;

namespace Shelvance.Core.MediaCover
{
    public class MediaCoversUpdatedEvent : IEvent
    {
        public Author Author { get; set; }
        public Book Book { get; set; }

        public MediaCoversUpdatedEvent(Author author)
        {
            Author = author;
        }

        public MediaCoversUpdatedEvent(Book book)
        {
            Book = book;
        }
    }
}
