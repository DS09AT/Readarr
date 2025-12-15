using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(039)]
    public class book_last_searched_time : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("Books").AddColumn("LastSearchTime").AsDateTimeOffset().Nullable();
        }
    }
}
