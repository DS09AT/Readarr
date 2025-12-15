using System.Collections.Generic;
using Shelvance.Common.Messaging;
using Shelvance.Core.Books;

namespace Shelvance.Core.ImportLists
{
    public class ImportListSyncCompleteEvent : IEvent
    {
        public List<Book> ProcessedDecisions { get; private set; }

        public ImportListSyncCompleteEvent(List<Book> processedDecisions)
        {
            ProcessedDecisions = processedDecisions;
        }
    }
}
