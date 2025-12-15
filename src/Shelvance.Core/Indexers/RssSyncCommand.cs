using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Indexers
{
    public class RssSyncCommand : Command
    {
        public override bool SendUpdatesToClient => true;
        public override bool IsLongRunning => true;
    }
}
