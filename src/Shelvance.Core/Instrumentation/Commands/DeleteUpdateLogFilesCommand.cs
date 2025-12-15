using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Instrumentation.Commands
{
    public class DeleteUpdateLogFilesCommand : Command
    {
        public override bool SendUpdatesToClient => true;
    }
}
