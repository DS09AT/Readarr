using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(21)]
    public class add_on_delete_to_notifications : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("Notifications").AddColumn("OnAuthorDelete").AsBoolean().WithDefaultValue(false);
            Alter.Table("Notifications").AddColumn("OnBookDelete").AsBoolean().WithDefaultValue(false);
            Alter.Table("Notifications").AddColumn("OnBookFileDelete").AsBoolean().WithDefaultValue(false);
            Alter.Table("Notifications").AddColumn("OnBookFileDeleteForUpgrade").AsBoolean().WithDefaultValue(false);
        }
    }
}
