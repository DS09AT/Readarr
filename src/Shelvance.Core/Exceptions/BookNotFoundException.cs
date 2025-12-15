using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Exceptions
{
    public class BookNotFoundException : ShelvanceException
    {
        public string ForeignBookId { get; set; }

        public BookNotFoundException(string foreignBookId)
            : base($"Book with id {foreignBookId} was not found, it may have been removed from metadata server.")
        {
            ForeignBookId = foreignBookId;
        }

        public BookNotFoundException(string foreignBookId, string message, params object[] args)
            : base(message, args)
        {
            ForeignBookId = foreignBookId;
        }

        public BookNotFoundException(string foreignBookId, string message)
            : base(message)
        {
            ForeignBookId = foreignBookId;
        }
    }
}
