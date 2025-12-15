using Shelvance.Core.Books.Commands;
using Shelvance.Core.Books.Events;
using Shelvance.Core.Messaging.Commands;
using Shelvance.Core.Messaging.Events;

namespace Shelvance.Core.Books
{
    public class AuthorEditedService : IHandle<AuthorEditedEvent>
    {
        private readonly IManageCommandQueue _commandQueueManager;

        public AuthorEditedService(IManageCommandQueue commandQueueManager)
        {
            _commandQueueManager = commandQueueManager;
        }

        public void Handle(AuthorEditedEvent message)
        {
            // Refresh Author is we change BookType Preferences
            if (message.Author.MetadataProfileId != message.OldAuthor.MetadataProfileId)
            {
                _commandQueueManager.Push(new RefreshAuthorCommand(message.Author.Id, false));
            }
        }
    }
}
