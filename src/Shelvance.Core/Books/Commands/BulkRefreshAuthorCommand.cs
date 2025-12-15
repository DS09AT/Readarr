using System.Collections.Generic;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Books.Commands
{
    public class BulkRefreshAuthorCommand : Command
    {
        public BulkRefreshAuthorCommand()
        {
        }

        public BulkRefreshAuthorCommand(List<int> authorIds, bool areNewAuthors = false)
        {
            AuthorIds = authorIds;
            AreNewAuthors = areNewAuthors;
        }

        public List<int> AuthorIds { get; set; }
        public bool AreNewAuthors { get; set; }

        public override bool SendUpdatesToClient => true;

        public override bool UpdateScheduledTask => false;
    }
}
