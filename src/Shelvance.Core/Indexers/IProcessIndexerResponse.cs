using System.Collections.Generic;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.Indexers
{
    public interface IParseIndexerResponse
    {
        IList<ReleaseInfo> ParseResponse(IndexerResponse indexerResponse);
    }
}
