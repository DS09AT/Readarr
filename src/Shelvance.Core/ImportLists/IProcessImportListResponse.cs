using System.Collections.Generic;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.ImportLists
{
    public interface IParseImportListResponse
    {
        IList<ImportListItemInfo> ParseResponse(ImportListResponse importListResponse);
    }
}
