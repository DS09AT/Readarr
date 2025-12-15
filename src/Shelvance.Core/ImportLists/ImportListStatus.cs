using System;
using Shelvance.Core.ThingiProvider.Status;

namespace Shelvance.Core.ImportLists
{
    public class ImportListStatus : ProviderStatusBase
    {
        public DateTime? LastInfoSync { get; set; }
    }
}
