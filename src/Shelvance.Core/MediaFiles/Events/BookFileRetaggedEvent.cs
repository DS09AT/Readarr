using System;
using System.Collections.Generic;
using Shelvance.Common.Messaging;
using Shelvance.Core.Books;

namespace Shelvance.Core.MediaFiles.Events
{
    public class BookFileRetaggedEvent : IEvent
    {
        public Author Author { get; private set; }
        public BookFile BookFile { get; private set; }
        public Dictionary<string, Tuple<string, string>> Diff { get; private set; }
        public bool Scrubbed { get; private set; }

        public BookFileRetaggedEvent(Author author,
                                      BookFile bookFile,
                                      Dictionary<string, Tuple<string, string>> diff,
                                      bool scrubbed)
        {
            Author = author;
            BookFile = bookFile;
            Diff = diff;
            Scrubbed = scrubbed;
        }
    }
}
