using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(18)]
    public class AddSeriesPosition : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("SeriesBookLink").AddColumn("SeriesPosition").AsInt32().WithDefaultValue(0);
        }
    }
}
