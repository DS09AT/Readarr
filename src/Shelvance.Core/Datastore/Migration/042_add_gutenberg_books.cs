using FluentMigrator;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(042)]
    public class add_gutenberg_books : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Create.TableForModel("GutenbergBooks")
                .WithColumn("GutenbergId").AsInt32().Unique()
                .WithColumn("Title").AsString()
                .WithColumn("Author").AsString()
                .WithColumn("Language").AsString().Nullable()
                .WithColumn("Subjects").AsString().Nullable()
                .WithColumn("Copyright").AsBoolean().Nullable()
                .WithColumn("Downloads").AsInt32().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime();

            Create.Index("IX_GutenbergBooks_Title")
                .OnTable("GutenbergBooks")
                .OnColumn("Title");

            Create.Index("IX_GutenbergBooks_Author")
                .OnTable("GutenbergBooks")
                .OnColumn("Author");

            Create.Index("IX_GutenbergBooks_Language")
                .OnTable("GutenbergBooks")
                .OnColumn("Language");
        }
    }
}
