using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Shelvance.Core.MediaFiles.BookImport.Identification;
using Shelvance.Core.MetadataSource;
using Shelvance.Core.MetadataSource.Goodreads;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.MediaFiles.BookImport.Identification
{
    [TestFixture]
    public class CandidateServiceFixture : CoreTest<CandidateService>
    {
        [Test]
        public void should_not_throw_on_goodreads_exception()
        {
            Mocker.GetMock<ISearchForNewBook>()
                .Setup(s => s.SearchForNewBook(It.IsAny<string>(), It.IsAny<string>(), true))
                .Throws(new GoodreadsException("Bad search"));

            var edition = new LocalEdition
            {
                LocalBooks = new List<LocalBook>
                {
                    new LocalBook
                    {
                        FileTrackInfo = new ParsedTrackInfo
                        {
                            Authors = new List<string> { "Author" },
                            BookTitle = "Book"
                        }
                    }
                }
            };

            Subject.GetRemoteCandidates(edition, null).Should().BeEmpty();
        }
    }
}
