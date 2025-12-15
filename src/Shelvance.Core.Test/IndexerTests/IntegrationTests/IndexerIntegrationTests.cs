using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Common.Extensions;
using Shelvance.Core.Indexers;
using Shelvance.Core.IndexerSearch.Definitions;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Test.Framework;
using Shelvance.Test.Common.Categories;

namespace Shelvance.Core.Test.IndexerTests.IntegrationTests
{
    [IntegrationTest]
    public class IndexerIntegrationTests : CoreTest
    {
        private BookSearchCriteria _bookSearchCriteria;

        [SetUp]
        public void SetUp()
        {
            UseRealHttp();

            _bookSearchCriteria = new BookSearchCriteria()
            {
            };
        }

        private void ValidateTorrentResult(IList<ReleaseInfo> reports, bool hasSize = false, bool hasInfoUrl = false, bool hasMagnet = false)
        {
            reports.Should().OnlyContain(c => c.GetType() == typeof(TorrentInfo));

            ValidateResult(reports, hasSize, hasInfoUrl);

            reports.Should().OnlyContain(c => c.DownloadProtocol == DownloadProtocol.Torrent);

            if (hasMagnet)
            {
                reports.Cast<TorrentInfo>().Should().OnlyContain(c => c.MagnetUrl.StartsWith("magnet:"));
            }
        }

        private void ValidateResult(IList<ReleaseInfo> reports, bool hasSize = false, bool hasInfoUrl = false)
        {
            reports.Should().NotBeEmpty();
            reports.Should().OnlyContain(c => c.Title.IsNotNullOrWhiteSpace());
            reports.Should().OnlyContain(c => c.PublishDate.Year > 2000);
            reports.Should().OnlyContain(c => c.DownloadUrl.IsNotNullOrWhiteSpace());
            reports.Should().OnlyContain(c => c.DownloadUrl.StartsWith("http"));

            if (hasInfoUrl)
            {
                reports.Should().OnlyContain(c => c.InfoUrl.IsNotNullOrWhiteSpace());
            }

            if (hasSize)
            {
                reports.Should().OnlyContain(c => c.Size > 0);
            }
        }
    }
}
