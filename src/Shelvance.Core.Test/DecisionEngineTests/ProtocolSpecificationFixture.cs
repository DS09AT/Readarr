using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Shelvance.Core.Books;
using Shelvance.Core.DecisionEngine.Specifications;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Profiles.Delay;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.DecisionEngineTests
{
    [TestFixture]
    public class ProtocolSpecificationFixture : CoreTest<ProtocolSpecification>
    {
        private RemoteBook _remoteBook;
        private DelayProfile _delayProfile;

        [SetUp]
        public void Setup()
        {
            _remoteBook = new RemoteBook();
            _remoteBook.Release = new ReleaseInfo();
            _remoteBook.Author = new Author();

            _delayProfile = new DelayProfile();

            Mocker.GetMock<IDelayProfileService>()
                  .Setup(s => s.BestForTags(It.IsAny<HashSet<int>>()))
                  .Returns(_delayProfile);
        }

        private void GivenProtocol(DownloadProtocol downloadProtocol)
        {
            _remoteBook.Release.DownloadProtocol = downloadProtocol;
        }

        [Test]
        public void should_be_true_if_usenet_and_usenet_is_enabled()
        {
            GivenProtocol(DownloadProtocol.Usenet);
            _delayProfile.EnableUsenet = true;

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().Be(true);
        }

        [Test]
        public void should_be_true_if_torrent_and_torrent_is_enabled()
        {
            GivenProtocol(DownloadProtocol.Torrent);
            _delayProfile.EnableTorrent = true;

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().Be(true);
        }

        [Test]
        public void should_be_false_if_usenet_and_usenet_is_disabled()
        {
            GivenProtocol(DownloadProtocol.Usenet);
            _delayProfile.EnableUsenet = false;

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().Be(false);
        }

        [Test]
        public void should_be_false_if_torrent_and_torrent_is_disabled()
        {
            GivenProtocol(DownloadProtocol.Torrent);
            _delayProfile.EnableTorrent = false;

            Subject.IsSatisfiedBy(_remoteBook, null).Accepted.Should().Be(false);
        }
    }
}
