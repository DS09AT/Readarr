using System;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Core.Configuration;
using Shelvance.Core.DecisionEngine.Specifications;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.DecisionEngineTests
{
    [TestFixture]

    public class MinimumAgeSpecificationFixture : CoreTest<MinimumAgeSpecification>
    {
        private RemoteBook _remoteBook;

        [SetUp]
        public void Setup()
        {
            _remoteBook = new RemoteBook
            {
                Release = new ReleaseInfo() { DownloadProtocol = DownloadProtocol.Usenet }
            };
        }

        private void WithMinimumAge(int minutes)
        {
            Mocker.GetMock<IConfigService>().SetupGet(c => c.MinimumAge).Returns(minutes);
        }

        private void WithAge(int minutes)
        {
            _remoteBook.Release.PublishDate = DateTime.UtcNow.AddMinutes(-minutes);
        }

        [Test]
        public void should_return_true_when_minimum_age_is_set_to_zero()
        {
            WithMinimumAge(0);
            WithAge(100);

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_true_when_age_is_greater_than_minimum_age()
        {
            WithMinimumAge(30);
            WithAge(100);

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().BeTrue();
        }

        [Test]
        public void should_return_false_when_age_is_less_than_minimum_age()
        {
            WithMinimumAge(30);
            WithAge(10);

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().BeFalse();
        }
    }
}
