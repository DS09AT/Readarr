using System.Collections.Generic;
using System.Threading.Tasks;
using Shelvance.Common.Http;
using Shelvance.Core.IndexerSearch.Definitions;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.Indexers
{
    public interface IIndexer : IProvider
    {
        bool SupportsRss { get; }
        bool SupportsSearch { get; }
        DownloadProtocol Protocol { get; }

        Task<IList<ReleaseInfo>> FetchRecent();
        Task<IList<ReleaseInfo>> Fetch(BookSearchCriteria searchCriteria);
        Task<IList<ReleaseInfo>> Fetch(AuthorSearchCriteria searchCriteria);
        HttpRequest GetDownloadRequest(string link);
    }
}
