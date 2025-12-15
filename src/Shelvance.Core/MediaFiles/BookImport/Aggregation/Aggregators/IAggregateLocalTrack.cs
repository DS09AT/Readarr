namespace Shelvance.Core.MediaFiles.BookImport.Aggregation.Aggregators
{
    public interface IAggregate<T>
    {
        T Aggregate(T item, bool otherFiles);
    }
}
