using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Core.Housekeeping.Housekeepers;
using Shelvance.Core.MediaFiles;
using Shelvance.Core.Qualities;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.Housekeeping.Housekeepers
{
    [TestFixture]
    public class CleanupOrphanedBookFilesFixture : DbTest<CleanupOrphanedBookFiles, BookFile>
    {
        [Test]
        public void should_unlink_orphaned_track_files()
        {
            var trackFile = Builder<BookFile>.CreateNew()
                .With(h => h.Quality = new QualityModel())
                .With(h => h.EditionId = 1)
                .BuildNew();

            Db.Insert(trackFile);
            Subject.Clean();
            AllStoredModels[0].EditionId.Should().Be(0);
        }
    }
}
