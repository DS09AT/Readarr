using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Instrumentation.Commands
{
    public class ClearLogCommand : Command
    {
        public override bool SendUpdatesToClient => true;
    }
}
