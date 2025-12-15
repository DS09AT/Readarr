using Shelvance.Common.Exceptions;

namespace Shelvance.Core.ImportLists.Exceptions
{
    public class ImportListException : ShelvanceException
    {
        private readonly ImportListResponse _importListResponse;

        public ImportListException(ImportListResponse response, string message, params object[] args)
            : base(message, args)
        {
            _importListResponse = response;
        }

        public ImportListException(ImportListResponse response, string message)
            : base(message)
        {
            _importListResponse = response;
        }

        public ImportListResponse Response => _importListResponse;
    }
}
