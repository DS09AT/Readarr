using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using Moq;
using NLog;
using NUnit.Framework;
using Shelvance.Common.Http;
using Shelvance.Core.Configuration;
using Shelvance.Core.Download;
using Shelvance.Core.Download.Clients.Pneumatic;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Test.Framework;
using Shelvance.Core.Test.IndexerTests;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.Download.DownloadClientTests
{
    [TestFixture]
    public class PneumaticProviderFixture : CoreTest<Pneumatic>
    {
        private const string _nzbUrl = "http://www.nzbs.com/url";
        private const string _title = "30.Rock.S01E05.hdtv.xvid-LoL";
        private string _pneumaticFolder;
        private string _strmFolder;
        private string _nzbPath;
        private RemoteBook _remoteBook;
        private IIndexer _indexer;
        private DownloadClientItem _downloadClientItem;

        [SetUp]
        public void Setup()
        {
            _pneumaticFolder = @"d:\nzb\pneumatic\".AsOsAgnostic();

            _nzbPath = Path.Combine(_pneumaticFolder, _title + ".nzb").AsOsAgnostic();
            _strmFolder = @"d:\unsorted tv\".AsOsAgnostic();

            _remoteBook = new RemoteBook();
            _remoteBook.Release = new ReleaseInfo();
            _remoteBook.Release.Title = _title;
            _remoteBook.Release.DownloadUrl = _nzbUrl;

            _remoteBook.ParsedBookInfo = new ParsedBookInfo();

            _indexer = new TestIndexer(Mocker.Resolve<IHttpClient>(),
                Mocker.Resolve<IIndexerStatusService>(),
                Mocker.Resolve<IConfigService>(),
                Mocker.Resolve<IParsingService>(),
                Mocker.Resolve<Logger>());

            _downloadClientItem = Builder<DownloadClientItem>
                                  .CreateNew().With(d => d.DownloadId = "_Droned.S01E01.Pilot.1080p.WEB-DL-DRONE_0")
                                  .Build();

            Subject.Definition = new DownloadClientDefinition();
            Subject.Definition.Settings = new PneumaticSettings
            {
                NzbFolder = _pneumaticFolder,
                StrmFolder = _strmFolder
            };
        }

        private void WithFailedDownload()
        {
            Mocker.GetMock<IHttpClient>().Setup(c => c.DownloadFileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new WebException());
        }

        [Test]
        public async Task should_download_file_if_it_doesnt_exist()
        {
            await Subject.Download(_remoteBook, _indexer);

            Mocker.GetMock<IHttpClient>().Verify(c => c.DownloadFileAsync(_nzbUrl, _nzbPath, null), Times.Once());
        }

        [Test]
        public void should_throw_on_failed_download()
        {
            WithFailedDownload();

            Assert.ThrowsAsync<WebException>(async () => await Subject.Download(_remoteBook, _indexer));
        }

        [Test]
        public void should_throw_if_discography_download()
        {
            _remoteBook.Release.Title = "Alien Ant Farm - Discography";
            _remoteBook.ParsedBookInfo.Discography = true;

            Assert.ThrowsAsync<NotSupportedException>(async () => await Subject.Download(_remoteBook, _indexer));
        }

        [Test]
        public void should_throw_item_is_removed()
        {
            Assert.Throws<NotSupportedException>(() => Subject.RemoveItem(_downloadClientItem, true));
        }

        [Test]
        public async Task should_replace_illegal_characters_in_title()
        {
            var illegalTitle = "Saturday Night Live - S38E08 - Jeremy Renner/Maroon 5 [SDTV]";
            var expectedFilename = Path.Combine(_pneumaticFolder, "Saturday Night Live - S38E08 - Jeremy Renner+Maroon 5 [SDTV].nzb");
            _remoteBook.Release.Title = illegalTitle;

            await Subject.Download(_remoteBook, _indexer);

            Mocker.GetMock<IHttpClient>().Verify(c => c.DownloadFileAsync(It.IsAny<string>(), expectedFilename, null), Times.Once());
        }
    }
}
