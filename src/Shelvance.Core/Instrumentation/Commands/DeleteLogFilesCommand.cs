using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Instrumentation.Commands
{
    public class DeleteLogFilesCommand : Command
    {
        public override bool SendUpdatesToClient => true;
    }
}
