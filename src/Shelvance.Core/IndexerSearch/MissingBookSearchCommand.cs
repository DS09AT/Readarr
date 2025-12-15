using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.IndexerSearch
{
    public class MissingBookSearchCommand : Command
    {
        public int? AuthorId { get; set; }

        public override bool SendUpdatesToClient => true;

        public MissingBookSearchCommand()
        {
        }

        public MissingBookSearchCommand(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
