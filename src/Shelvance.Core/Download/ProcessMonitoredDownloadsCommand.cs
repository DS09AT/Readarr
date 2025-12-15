using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Download
{
    public class ProcessMonitoredDownloadsCommand : Command
    {
        public override bool RequiresDiskAccess => true;

        public override bool IsLongRunning => true;
    }
}
