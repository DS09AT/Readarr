using System;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Core.Download.Pending;
using Shelvance.Core.Housekeeping.Housekeepers;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Test.Framework;

namespace Shelvance.Core.Test.Housekeeping.Housekeepers
{
    [TestFixture]
    public class CleanupDownloadClientUnavailablePendingReleasesFixture : DbTest<CleanupDownloadClientUnavailablePendingReleases, PendingRelease>
    {
        [Test]
        public void should_delete_old_DownloadClientUnavailable_pending_items()
        {
            var pendingRelease = Builder<PendingRelease>.CreateNew()
                .With(h => h.Reason = PendingReleaseReason.DownloadClientUnavailable)
                .With(h => h.Added = DateTime.UtcNow.AddDays(-21))
                .With(h => h.ParsedBookInfo = new ParsedBookInfo())
                .With(h => h.Release = new ReleaseInfo())
                .BuildNew();

            Db.Insert(pendingRelease);
            Subject.Clean();
            AllStoredModels.Should().BeEmpty();
        }

        [Test]
        public void should_delete_old_Fallback_pending_items()
        {
            var pendingRelease = Builder<PendingRelease>.CreateNew()
                .With(h => h.Reason = PendingReleaseReason.Fallback)
                .With(h => h.Added = DateTime.UtcNow.AddDays(-21))
                .With(h => h.ParsedBookInfo = new ParsedBookInfo())
                .With(h => h.Release = new ReleaseInfo())
                .BuildNew();

            Db.Insert(pendingRelease);
            Subject.Clean();
            AllStoredModels.Should().BeEmpty();
        }

        [Test]
        public void should_not_delete_old_Delay_pending_items()
        {
            var pendingRelease = Builder<PendingRelease>.CreateNew()
                .With(h => h.Reason = PendingReleaseReason.Delay)
                .With(h => h.Added = DateTime.UtcNow.AddDays(-21))
                .With(h => h.ParsedBookInfo = new ParsedBookInfo())
                .With(h => h.Release = new ReleaseInfo())
                .BuildNew();

            Db.Insert(pendingRelease);
            Subject.Clean();
            AllStoredModels.Should().HaveCount(1);
        }
    }
}
