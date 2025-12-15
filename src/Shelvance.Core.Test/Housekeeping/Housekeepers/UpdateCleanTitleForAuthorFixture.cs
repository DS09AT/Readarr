using FizzWare.NBuilder;
using Moq;
using NUnit.Framework;
using Shelvance.Core.Books;
using Shelvance.Core.Housekeeping.Housekeepers;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.Housekeeping.Housekeepers
{
    [TestFixture]
    public class UpdateCleanTitleForAuthorFixture : CoreTest<UpdateCleanTitleForAuthor>
    {
        [Test]
        public void should_update_clean_title()
        {
            var author = Builder<Author>.CreateNew()
                                        .With(s => s.Name = "Full Name")
                                        .With(s => s.CleanName = "unclean")
                                        .Build();

            Mocker.GetMock<IAuthorRepository>()
                 .Setup(s => s.All())
                 .Returns(new[] { author });

            Subject.Clean();

            Mocker.GetMock<IAuthorRepository>()
                .Verify(v => v.Update(It.Is<Author>(s => s.CleanName == "fullname")), Times.Once());
        }

        [Test]
        public void should_not_update_unchanged_title()
        {
            var author = Builder<Author>.CreateNew()
                                        .With(s => s.Name = "Full Name")
                                        .With(s => s.CleanName = "fullname")
                                        .Build();

            Mocker.GetMock<IAuthorRepository>()
                 .Setup(s => s.All())
                 .Returns(new[] { author });

            Subject.Clean();

            Mocker.GetMock<IAuthorRepository>()
                .Verify(v => v.Update(It.Is<Author>(s => s.CleanName == "fullname")), Times.Never());
        }
    }
}
