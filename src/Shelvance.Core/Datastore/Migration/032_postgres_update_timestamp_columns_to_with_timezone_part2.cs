using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(032)]
    public class postgres_update_timestamp_columns_to_with_timezone_part2 : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("DownloadHistory").AlterColumn("Date").AsDateTimeOffset().Nullable();
            Alter.Table("ImportListStatus").AlterColumn("LastInfoSync").AsDateTimeOffset().Nullable();
        }
    }
}
