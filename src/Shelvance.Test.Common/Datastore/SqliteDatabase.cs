using System.IO;
using NUnit.Framework;
using Shelvance.Core.Datastore.Migration.Framework;

namespace Shelvance.Test.Common.Datastore
{
    public static class SqliteDatabase
    {
        public static string GetCachedDb(MigrationType type)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, $"cached_{type}.db");
        }
    }
}
