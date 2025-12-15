using Shelvance.Core.MetadataSource.Goodreads;

namespace Shelvance.Core.MetadataSource
{
    public interface IProvideSeriesInfo
    {
        SeriesResource GetSeriesInfo(int id, bool useCache = true);
    }
}
