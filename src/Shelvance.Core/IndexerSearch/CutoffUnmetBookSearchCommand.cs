using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.IndexerSearch
{
    public class CutoffUnmetBookSearchCommand : Command
    {
        public int? AuthorId { get; set; }

        public override bool SendUpdatesToClient => true;

        public CutoffUnmetBookSearchCommand()
        {
        }

        public CutoffUnmetBookSearchCommand(int authorId)
        {
            AuthorId = authorId;
        }
    }
}
