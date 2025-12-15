using System.Collections.Generic;
using Shelvance.Common.Messaging;
using Shelvance.Core.Books;

namespace Shelvance.Core.MediaFiles.Events
{
    public class AuthorRenamedEvent : IEvent
    {
        public Author Author { get; private set; }
        public List<RenamedBookFile> RenamedFiles { get; private set; }

        public AuthorRenamedEvent(Author author, List<RenamedBookFile> renamedFiles)
        {
            Author = author;
            RenamedFiles = renamedFiles;
        }
    }
}
