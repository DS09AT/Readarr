using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(19)]
    public class AddNewItemMonitorType : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("Authors").AddColumn("MonitorNewItems").AsInt32().WithDefaultValue(0);
            Alter.Table("RootFolders").AddColumn("DefaultNewItemMonitorOption").AsInt32().WithDefaultValue(0);
            Alter.Table("ImportLists").AddColumn("MonitorNewItems").AsInt32().WithDefaultValue(0);
        }
    }
}
