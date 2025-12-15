using System;
using System.Collections.Generic;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.ImportLists
{
    public interface IImportList : IProvider
    {
        ImportListType ListType { get; }
        TimeSpan MinRefreshInterval { get; }
        IList<ImportListItemInfo> Fetch();
    }
}
