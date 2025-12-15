using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(027)]
    public class remove_omg : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Delete.FromTable("Indexers").Row(new { Implementation = "Omgwtfnzbs" });
            Delete.FromTable("Indexers").Row(new { Implementation = "Rarbg" });
        }
    }
}
