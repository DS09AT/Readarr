using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(024)]
    public class add_update_history : ShelvanceMigrationBase
    {
        protected override void LogDbUpgrade()
        {
            Create.TableForModel("UpdateHistory")
                  .WithColumn("Date").AsDateTime().NotNullable().Indexed()
                  .WithColumn("Version").AsString().NotNullable()
                  .WithColumn("EventType").AsInt32().NotNullable();
        }
    }
}
