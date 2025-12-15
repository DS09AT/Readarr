using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(004)]
    public class rename_supports_on_track_retag : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Rename.Column("OnTrackRetag").OnTable("Notifications").To("OnBookRetag");
        }
    }
}
