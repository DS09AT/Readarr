using System.Collections.Generic;
using Shelvance.Common.Messaging;

namespace Shelvance.Core.Books.Events
{
    public class AuthorsImportedEvent : IEvent
    {
        public List<int> AuthorIds { get; private set; }
        public bool DoRefresh { get; private set; }

        public AuthorsImportedEvent(List<int> authorIds, bool doRefresh = true)
        {
            AuthorIds = authorIds;
            DoRefresh = doRefresh;
        }
    }
}
