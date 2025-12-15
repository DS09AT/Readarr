using Dapper;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class CleanupOrphanedBlocklist : IHousekeepingTask
    {
        private readonly IMainDatabase _database;

        public CleanupOrphanedBlocklist(IMainDatabase database)
        {
            _database = database;
        }

        public void Clean()
        {
            using var mapper = _database.OpenConnection();
            mapper.Execute(@"DELETE FROM ""Blocklist""
                             WHERE ""Id"" IN (
                             SELECT ""Blocklist"".""Id"" FROM ""Blocklist""
                             LEFT OUTER JOIN ""Authors""
                             ON ""Blocklist"".""AuthorId"" = ""Authors"".""Id""
                             WHERE ""Authors"".""Id"" IS NULL)");
        }
    }
}
