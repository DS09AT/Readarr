using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(7)]
    public class update_notifiarr : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Execute.Sql("UPDATE \"Notifications\" SET \"Implementation\" = Replace(\"Implementation\", 'DiscordNotifier', 'Notifiarr'),\"ConfigContract\" = Replace(\"ConfigContract\", 'DiscordNotifierSettings', 'NotifiarrSettings') WHERE \"Implementation\" = 'DiscordNotifier';");
        }
    }
}
