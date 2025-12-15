using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(010)]
    public class add_bookfile_part : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("BookFiles").AddColumn("Part").AsInt32().NotNullable().WithDefaultValue(1);
        }
    }
}
