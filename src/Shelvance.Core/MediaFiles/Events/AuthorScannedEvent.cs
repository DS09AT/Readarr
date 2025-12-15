using Shelvance.Common.Messaging;
using Shelvance.Core.Books;

namespace Shelvance.Core.MediaFiles.Events
{
    public class AuthorScannedEvent : IEvent
    {
        public Author Author { get; private set; }

        public AuthorScannedEvent(Author author)
        {
            Author = author;
        }
    }
}
