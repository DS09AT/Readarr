using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.Download.Aggregation.Aggregators
{
    public interface IAggregateRemoteBook
    {
        RemoteBook Aggregate(RemoteBook remoteBook);
    }
}
