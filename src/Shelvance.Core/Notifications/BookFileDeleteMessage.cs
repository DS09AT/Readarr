using Shelvance.Core.Books;
using Shelvance.Core.MediaFiles;

namespace Shelvance.Core.Notifications
{
    public class BookFileDeleteMessage
    {
        public string Message { get; set; }
        public Book Book { get; set; }
        public BookFile BookFile { get; set; }

        public DeleteMediaFileReason Reason { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
