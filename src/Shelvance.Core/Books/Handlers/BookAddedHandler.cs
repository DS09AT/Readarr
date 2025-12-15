using Shelvance.Core.Books.Commands;
using Shelvance.Core.Books.Events;
using Shelvance.Core.Messaging.Commands;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Books
{
    public class BookAddedHandler : IHandle<BookAddedEvent>
    {
        private readonly IManageCommandQueue _commandQueueManager;

        public BookAddedHandler(IManageCommandQueue commandQueueManager)
        {
            _commandQueueManager = commandQueueManager;
        }

        public void Handle(BookAddedEvent message)
        {
            if (message.DoRefresh)
            {
                _commandQueueManager.Push(new RefreshAuthorCommand(message.Book.Author.Value.Id));
            }
        }
    }
}
