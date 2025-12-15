using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(035)]
    public class add_download_client_tags : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Alter.Table("DownloadClients").AddColumn("Tags").AsString().Nullable();
        }
    }
}
