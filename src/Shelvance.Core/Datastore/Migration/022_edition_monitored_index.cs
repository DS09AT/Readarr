using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(22)]
    public class EditionMonitoredIndex : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Create.Index().OnTable("Editions").OnColumn("Monitored");
        }
    }
}
