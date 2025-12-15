using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(012)]
    public class add_bookfile_part_naming_token : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Execute.Sql("UPDATE \"NamingConfig\" SET \"StandardBookFormat\" = \"StandardBookFormat\" || '{ (PartNumber)}'");
        }
    }
}
