using Moq;
using NUnit.Framework;
using Shelvance.Core.Configuration;
using Shelvance.Core.HealthCheck.Checks;
using Shelvance.Core.Localization;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.HealthCheck.Checks
{
    [TestFixture]
    public class ReleaseBranchCheckFixture : CoreTest<ReleaseBranchCheck>
    {
        [SetUp]
        public void Setup()
        {
            Mocker.GetMock<ILocalizationService>()
                  .Setup(s => s.GetLocalizedString(It.IsAny<string>()))
                  .Returns("Some Warning Message");
        }

        private void GivenValidBranch(string branch)
        {
            Mocker.GetMock<IConfigFileProvider>()
                    .SetupGet(s => s.Branch)
                    .Returns(branch);
        }

        [TestCase("book-index")]
        [TestCase("phantom")]

        // ToDo: Master should be valid once released
        [TestCase("master")]
        public void should_return_warning_when_branch_is_not_valid(string branch)
        {
            GivenValidBranch(branch);

            Subject.Check().ShouldBeWarning();
        }

        [TestCase("nightly")]
        [TestCase("Nightly")]
        [TestCase("develop")]
        [TestCase("Develop")]
        public void should_return_no_warning_when_branch_valid(string branch)
        {
            GivenValidBranch(branch);

            Subject.Check().ShouldBeOk();
        }
    }
}
