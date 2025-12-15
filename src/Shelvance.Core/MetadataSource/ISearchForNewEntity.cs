using System.Collections.Generic;

namespace Shelvance.Core.MetadataSource
{
    public interface ISearchForNewEntity
    {
        List<object> SearchForNewEntity(string title);
    }
}
