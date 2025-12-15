using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Shelvance.Common.Disk;
using Shelvance.Core.Books;
using Shelvance.Core.Configuration;
using Shelvance.Core.DecisionEngine.Specifications.RssSync;
using Shelvance.Core.IndexerSearch.Definitions;
using Shelvance.Core.MediaFiles;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Profiles.Qualities;
using Shelvance.Core.Qualities;
using Shelvance.Core.Test.Framework;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.DecisionEngineTests.RssSync
{
    [TestFixture]
    public class DeletedTrackFileSpecificationFixture : CoreTest<DeletedBookFileSpecification>
    {
        private RemoteBook _parseResultMulti;
        private RemoteBook _parseResultSingle;
        private BookFile _firstFile;
        private BookFile _secondFile;

        [SetUp]
        public void Setup()
        {
            _firstFile =
                new BookFile
                {
                    Id = 1,
                    Path = "/My.Author.S01E01.mp3",
                    Quality = new QualityModel(Quality.FLAC, new Revision(version: 1)),
                    DateAdded = DateTime.Now,
                    EditionId = 1
                };
            _secondFile =
                new BookFile
                {
                    Id = 2,
                    Path = "/My.Author.S01E02.mp3",
                    Quality = new QualityModel(Quality.FLAC, new Revision(version: 1)),
                    DateAdded = DateTime.Now,
                    EditionId = 2
                };

            var singleBookList = new List<Book> { new Book { Id = 1 } };
            var doubleBookList = new List<Book>
            {
                new Book { Id = 1 },
                new Book { Id = 2 }
            };

            var fakeAuthor = Builder<Author>.CreateNew()
                         .With(c => c.QualityProfile = new QualityProfile { Cutoff = Quality.FLAC.Id })
                         .With(c => c.Path = @"C:\Music\My.Author".AsOsAgnostic())
                         .Build();

            _parseResultMulti = new RemoteBook
            {
                Author = fakeAuthor,
                ParsedBookInfo = new ParsedBookInfo { Quality = new QualityModel(Quality.MP3, new Revision(version: 2)) },
                Books = doubleBookList
            };

            _parseResultSingle = new RemoteBook
            {
                Author = fakeAuthor,
                ParsedBookInfo = new ParsedBookInfo { Quality = new QualityModel(Quality.MP3, new Revision(version: 2)) },
                Books = singleBookList
            };

            GivenUnmonitorDeletedTracks(true);
        }

        private void GivenUnmonitorDeletedTracks(bool enabled)
        {
            Mocker.GetMock<IConfigService>()
                  .SetupGet(v => v.AutoUnmonitorPreviouslyDownloadedBooks)
                  .Returns(enabled);
        }

        private void SetupMediaFile(List<BookFile> files)
        {
            Mocker.GetMock<IMediaFileService>()
                              .Setup(v => v.GetFilesByBook(It.IsAny<int>()))
                              .Returns(files);
        }

        private void WithExistingFile(BookFile trackFile)
        {
            var path = trackFile.Path;

            Mocker.GetMock<IDiskProvider>()
                  .Setup(v => v.FileExists(path))
                  .Returns(true);
        }

        [Test]
        public void should_return_true_when_unmonitor_deleted_tracks_is_off()
        {
            GivenUnmonitorDeletedTracks(false);

            Subject.IsSatisfiedBy(_parseResultSingle, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_true_when_searching()
        {
            Subject.IsSatisfiedBy(_parseResultSingle, new AuthorSearchCriteria()).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_true_if_file_exists()
        {
            WithExistingFile(_firstFile);
            SetupMediaFile(new List<BookFile> { _firstFile });

            Subject.IsSatisfiedBy(_parseResultSingle, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_false_if_file_is_missing()
        {
            SetupMediaFile(new List<BookFile> { _firstFile });
            Subject.IsSatisfiedBy(_parseResultSingle, null).Accepted.Should().BeFalse();
        }

        [Test]
        public void should_return_true_if_both_of_multiple_episode_exist()
        {
            WithExistingFile(_firstFile);
            WithExistingFile(_secondFile);
            SetupMediaFile(new List<BookFile> { _firstFile, _secondFile });

            Subject.IsSatisfiedBy(_parseResultMulti, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_false_if_one_of_multiple_episode_is_missing()
        {
            WithExistingFile(_firstFile);
            SetupMediaFile(new List<BookFile> { _firstFile, _secondFile });

            Subject.IsSatisfiedBy(_parseResultMulti, null).Accepted.Should().BeFalse();
        }
    }
}
