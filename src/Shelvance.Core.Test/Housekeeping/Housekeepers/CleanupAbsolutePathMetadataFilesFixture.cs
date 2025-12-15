using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Common.Extensions;
using Shelvance.Core.Extras.Metadata.Files;
using Shelvance.Core.Housekeeping.Housekeepers;
using Shelvance.Core.Test.Framework;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.Housekeeping.Housekeepers
{
    [TestFixture]
    public class CleanupAbsolutePathMetadataFilesFixture : DbTest<CleanupAbsolutePathMetadataFiles, MetadataFile>
    {
        [Test]
        public void should_not_delete_metadata_files_that_have_a_relative_path()
        {
            var relativePath = @"C:\Test\".AsOsAgnostic().GetRelativePath(@"C:\Test\Relative\Path".AsOsAgnostic());
            var file = Builder<MetadataFile>.CreateNew()
                                            .With(m => m.RelativePath = relativePath)
                                            .BuildNew();

            Db.Insert(file);
            Subject.Clean();
            AllStoredModels.Count.Should().Be(1);
        }

        [Test]
        public void should_delete_metadata_files_that_start_with_a_drive_letter()
        {
            var file = Builder<MetadataFile>.CreateNew()
                                            .With(m => m.RelativePath = @"C:\Relative\Path")
                                            .BuildNew();

            Db.Insert(file);
            Subject.Clean();
            AllStoredModels.Count.Should().Be(0);
        }

        [Test]
        public void should_delete_metadata_files_that_start_with_a_forward_slash()
        {
            var file = Builder<MetadataFile>.CreateNew()
                                            .With(m => m.RelativePath = @"/Relative/Path")
                                            .BuildNew();

            Db.Insert(file);
            Subject.Clean();
            AllStoredModels.Count.Should().Be(0);
        }

        [Test]
        public void should_delete_metadata_files_that_start_with_a_backslash()
        {
            var file = Builder<MetadataFile>.CreateNew()
                                            .With(m => m.RelativePath = @"\\Relative\Path")
                                            .BuildNew();

            Db.Insert(file);
            Subject.Clean();
            AllStoredModels.Count.Should().Be(0);
        }
    }
}
