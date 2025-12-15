using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(17)]
    public class ImportListMonitorExisting : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("ImportLists").AddColumn("ShouldMonitorExisting").AsBoolean().WithDefaultValue(false);
        }
    }
}
