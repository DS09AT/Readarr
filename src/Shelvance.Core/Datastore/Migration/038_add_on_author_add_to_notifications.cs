using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(038)]
    public class add_on_author_added_to_notifications : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("Notifications").AddColumn("OnAuthorAdded").AsBoolean().WithDefaultValue(false);
        }
    }
}
