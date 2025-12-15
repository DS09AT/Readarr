using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.ImportLists
{
    public class ImportListSyncCommand : Command
    {
        public int? DefinitionId { get; set; }

        public ImportListSyncCommand()
        {
        }

        public ImportListSyncCommand(int? definition)
        {
            DefinitionId = definition;
        }

        public override bool SendUpdatesToClient => true;

        public override bool IsTypeExclusive => true;

        public override bool UpdateScheduledTask => !DefinitionId.HasValue;
    }
}
