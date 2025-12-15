using System.Collections.Generic;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Books.Commands
{
    public class BulkRefreshBookCommand : Command
    {
        public BulkRefreshBookCommand()
        {
        }

        public BulkRefreshBookCommand(List<int> bookIds)
        {
            BookIds = bookIds;
        }

        public List<int> BookIds { get; set; }

        public override bool SendUpdatesToClient => true;
    }
}
