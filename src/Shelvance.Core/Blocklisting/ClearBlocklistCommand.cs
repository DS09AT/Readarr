using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Blocklisting
{
    public class ClearBlocklistCommand : Command
    {
        public override bool SendUpdatesToClient => true;
    }
}
