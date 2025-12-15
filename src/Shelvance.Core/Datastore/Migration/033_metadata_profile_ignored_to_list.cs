using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FluentMigrator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shelvance.Common.Serializer;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Core.Datastore.Migration
{
    [Migration(033)]
    public class metadata_profile_ignored_to_list : ShelvanceMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            Execute.WithConnection(MigrateMetadataProfileIgnored);
        }

        private void MigrateMetadataProfileIgnored(IDbConnection conn, IDbTransaction tran)
        {
            var updatedMetadataProfiles = new List<object>();

            using (var selectCommand = conn.CreateCommand())
            {
                selectCommand.Transaction = tran;
                selectCommand.CommandText = "SELECT \"Id\", \"Ignored\" FROM \"MetadataProfiles\"";

                using var reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var ignored = reader.GetValue(1).ToString() ?? string.Empty;

                    if (!string.IsNullOrWhiteSpace(ignored))
                    {
                        try
                        {
                            JsonConvert.DeserializeObject<JArray>(ignored);

                            continue;
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    ignored = ignored
                        .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        .Distinct()
                        .ToJson();

                    updatedMetadataProfiles.Add(new
                    {
                        Id = id,
                        Ignored = ignored
                    });
                }
            }

            var updatedMetadataProfilesSql = "UPDATE \"MetadataProfiles\" SET \"Ignored\" = @Ignored WHERE \"Id\" = @Id";
            conn.Execute(updatedMetadataProfilesSql, updatedMetadataProfiles, transaction: tran);
        }
    }
}
