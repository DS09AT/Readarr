using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(2)]
    public class ImportListSearch : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("ImportLists").AddColumn("ShouldSearch").AsBoolean().WithDefaultValue(true);
        }
    }
}
