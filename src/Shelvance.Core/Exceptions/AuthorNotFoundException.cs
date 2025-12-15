using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Exceptions
{
    public class AuthorNotFoundException : ShelvanceException
    {
        public string ForeignAuthorId { get; set; }

        public AuthorNotFoundException(string foreignAuthorId)
            : base($"Author with id {foreignAuthorId} was not found, it may have been removed from the metadata server.")
        {
            ForeignAuthorId = foreignAuthorId;
        }

        public AuthorNotFoundException(string foreignAuthorId, string message, params object[] args)
            : base(message, args)
        {
            ForeignAuthorId = foreignAuthorId;
        }

        public AuthorNotFoundException(string foreignAuthorId, string message)
            : base(message)
        {
            ForeignAuthorId = foreignAuthorId;
        }
    }
}
