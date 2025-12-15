using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Books.Commands
{
    public class MoveAuthorCommand : Command
    {
        public int AuthorId { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }

        public override bool SendUpdatesToClient => true;
        public override bool RequiresDiskAccess => true;
    }
}
