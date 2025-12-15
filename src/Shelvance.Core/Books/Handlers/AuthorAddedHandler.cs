using Shelvance.Core.Books.Commands;
using Shelvance.Core.Books.Events;
using Shelvance.Core.Messaging.Commands;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Books
{
    public class AuthorAddedHandler : IHandle<AuthorAddedEvent>,
                                      IHandle<AuthorsImportedEvent>
    {
        private readonly IManageCommandQueue _commandQueueManager;

        public AuthorAddedHandler(IManageCommandQueue commandQueueManager)
        {
            _commandQueueManager = commandQueueManager;
        }

        public void Handle(AuthorAddedEvent message)
        {
            if (message.DoRefresh)
            {
                _commandQueueManager.Push(new RefreshAuthorCommand(message.Author.Id, true));
            }
        }

        public void Handle(AuthorsImportedEvent message)
        {
            if (message.DoRefresh)
            {
                _commandQueueManager.Push(new BulkRefreshAuthorCommand(message.AuthorIds, true));
            }
        }
    }
}
