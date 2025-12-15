using Shelvance.Core.MetadataSource.Goodreads;

namespace Shelvance.Core.MetadataSource
{
    public interface IProvideListInfo
    {
        ListResource GetListInfo(int id, int page, bool useCache = true);
    }
}
