using Shelvance.Core.IndexerSearch.Definitions;

namespace Shelvance.Core.Indexers
{
    public interface IIndexerRequestGenerator
    {
        IndexerPageableRequestChain GetRecentRequests();
        IndexerPageableRequestChain GetSearchRequests(BookSearchCriteria searchCriteria);
        IndexerPageableRequestChain GetSearchRequests(AuthorSearchCriteria searchCriteria);
    }
}
