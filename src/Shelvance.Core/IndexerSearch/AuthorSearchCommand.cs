using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.IndexerSearch
{
    public class AuthorSearchCommand : Command
    {
        public int AuthorId { get; set; }

        public override bool SendUpdatesToClient => true;
    }
}
