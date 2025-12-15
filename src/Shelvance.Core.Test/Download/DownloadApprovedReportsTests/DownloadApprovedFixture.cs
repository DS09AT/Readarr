using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Shelvance.Core.Books;
using Shelvance.Core.DecisionEngine;
using Shelvance.Core.Download;
using Shelvance.Core.Download.Clients;
using Shelvance.Core.Download.Pending;
using Shelvance.Core.Exceptions;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Profiles.Qualities;
using Shelvance.Core.Qualities;
using Shelvance.Core.Test.Framework;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.Download.DownloadApprovedReportsTests
{
    [TestFixture]
    public class DownloadApprovedFixture : CoreTest<ProcessDownloadDecisions>
    {
        [SetUp]
        public void SetUp()
        {
            Mocker.GetMock<IPrioritizeDownloadDecision>()
                .Setup(v => v.PrioritizeDecisions(It.IsAny<List<DownloadDecision>>()))
                .Returns<List<DownloadDecision>>(v => v);
        }

        private Book GetBook(int id)
        {
            return Builder<Book>.CreateNew()
                            .With(e => e.Id = id)
                            .Build();
        }

        private RemoteBook GetRemoteBook(List<Book> books, QualityModel quality, DownloadProtocol downloadProtocol = DownloadProtocol.Usenet)
        {
            var remoteBook = new RemoteBook();
            remoteBook.ParsedBookInfo = new ParsedBookInfo();
            remoteBook.ParsedBookInfo.Quality = quality;

            remoteBook.Books = new List<Book>();
            remoteBook.Books.AddRange(books);

            remoteBook.Release = new ReleaseInfo();
            remoteBook.Release.DownloadProtocol = downloadProtocol;
            remoteBook.Release.PublishDate = DateTime.UtcNow;

            remoteBook.Author = Builder<Author>.CreateNew()
                .With(e => e.QualityProfile = new QualityProfile { Items = Qualities.QualityFixture.GetDefaultQualities() })
                .Build();

            return remoteBook;
        }

        [Test]
        public async Task should_download_report_if_book_was_not_already_downloaded()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.IsAny<RemoteBook>(), null), Times.Once());
        }

        [Test]
        public async Task should_only_download_book_once()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));
            decisions.Add(new DownloadDecision(remoteBook));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.IsAny<RemoteBook>(), null), Times.Once());
        }

        [Test]
        public async Task should_not_download_if_any_book_was_already_downloaded()
        {
            var remoteBook1 = GetRemoteBook(
                                                    new List<Book> { GetBook(1) },
                                                    new QualityModel(Quality.MP3));

            var remoteBook2 = GetRemoteBook(
                                                    new List<Book> { GetBook(1), GetBook(2) },
                                                    new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook1));
            decisions.Add(new DownloadDecision(remoteBook2));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.IsAny<RemoteBook>(), null), Times.Once());
        }

        [Test]
        public async Task should_return_downloaded_reports()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));

            var result = await Subject.ProcessDecisions(decisions);

            result.Grabbed.Should().HaveCount(1);
        }

        [Test]
        public async Task should_return_all_downloaded_reports()
        {
            var remoteBook1 = GetRemoteBook(
                                                    new List<Book> { GetBook(1) },
                                                    new QualityModel(Quality.MP3));

            var remoteBook2 = GetRemoteBook(
                                                    new List<Book> { GetBook(2) },
                                                    new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook1));
            decisions.Add(new DownloadDecision(remoteBook2));

            var result = await Subject.ProcessDecisions(decisions);

            result.Grabbed.Should().HaveCount(2);
        }

        [Test]
        public async Task should_only_return_downloaded_reports()
        {
            var remoteBook1 = GetRemoteBook(
                                                    new List<Book> { GetBook(1) },
                                                    new QualityModel(Quality.MP3));

            var remoteBook2 = GetRemoteBook(
                                                    new List<Book> { GetBook(2) },
                                                    new QualityModel(Quality.MP3));

            var remoteBook3 = GetRemoteBook(
                                                    new List<Book> { GetBook(2) },
                                                    new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook1));
            decisions.Add(new DownloadDecision(remoteBook2));
            decisions.Add(new DownloadDecision(remoteBook3));

            var result = await Subject.ProcessDecisions(decisions);

            result.Grabbed.Should().HaveCount(2);
        }

        [Test]
        public async Task should_not_add_to_downloaded_list_when_download_fails()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));

            Mocker.GetMock<IDownloadService>().Setup(s => s.DownloadReport(It.IsAny<RemoteBook>(), null)).Throws(new Exception());

            var result = await Subject.ProcessDecisions(decisions);

            result.Grabbed.Should().BeEmpty();

            ExceptionVerification.ExpectedWarns(1);
        }

        [Test]
        public void should_return_an_empty_list_when_none_are_appproved()
        {
            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(new RemoteBook(), new Rejection("Failure!")));
            decisions.Add(new DownloadDecision(new RemoteBook(), new Rejection("Failure!")));

            Subject.GetQualifiedReports(decisions).Should().BeEmpty();
        }

        [Test]
        public async Task should_not_grab_if_pending()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook, new Rejection("Failure!", RejectionType.Temporary)));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.IsAny<RemoteBook>(), null), Times.Never());
        }

        [Test]
        public async Task should_not_add_to_pending_if_book_was_grabbed()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));
            decisions.Add(new DownloadDecision(remoteBook, new Rejection("Failure!", RejectionType.Temporary)));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IPendingReleaseService>().Verify(v => v.AddMany(It.IsAny<List<Tuple<DownloadDecision, PendingReleaseReason>>>()), Times.Never());
        }

        [Test]
        public async Task should_add_to_pending_even_if_already_added_to_pending()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook, new Rejection("Failure!", RejectionType.Temporary)));
            decisions.Add(new DownloadDecision(remoteBook, new Rejection("Failure!", RejectionType.Temporary)));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IPendingReleaseService>().Verify(v => v.AddMany(It.IsAny<List<Tuple<DownloadDecision, PendingReleaseReason>>>()), Times.Once());
        }

        [Test]
        public async Task should_add_to_failed_if_already_failed_for_that_protocol()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));
            decisions.Add(new DownloadDecision(remoteBook));

            Mocker.GetMock<IDownloadService>().Setup(s => s.DownloadReport(It.IsAny<RemoteBook>(), null))
                  .Throws(new DownloadClientUnavailableException("Download client failed"));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.IsAny<RemoteBook>(), null), Times.Once());
        }

        [Test]
        public async Task should_not_add_to_failed_if_failed_for_a_different_protocol()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3), DownloadProtocol.Usenet);
            var remoteBook2 = GetRemoteBook(books, new QualityModel(Quality.MP3), DownloadProtocol.Torrent);

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));
            decisions.Add(new DownloadDecision(remoteBook2));

            Mocker.GetMock<IDownloadService>().Setup(s => s.DownloadReport(It.Is<RemoteBook>(r => r.Release.DownloadProtocol == DownloadProtocol.Usenet), null))
                  .Throws(new DownloadClientUnavailableException("Download client failed"));

            await Subject.ProcessDecisions(decisions);
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.Is<RemoteBook>(r => r.Release.DownloadProtocol == DownloadProtocol.Usenet), null), Times.Once());
            Mocker.GetMock<IDownloadService>().Verify(v => v.DownloadReport(It.Is<RemoteBook>(r => r.Release.DownloadProtocol == DownloadProtocol.Torrent), null), Times.Once());
        }

        [Test]
        public async Task should_add_to_rejected_if_release_unavailable_on_indexer()
        {
            var books = new List<Book> { GetBook(1) };
            var remoteBook = GetRemoteBook(books, new QualityModel(Quality.MP3));

            var decisions = new List<DownloadDecision>();
            decisions.Add(new DownloadDecision(remoteBook));

            Mocker.GetMock<IDownloadService>()
                  .Setup(s => s.DownloadReport(It.IsAny<RemoteBook>(), null))
                  .Throws(new ReleaseUnavailableException(remoteBook.Release, "That 404 Error is not just a Quirk"));

            var result = await Subject.ProcessDecisions(decisions);

            result.Grabbed.Should().BeEmpty();
            result.Rejected.Should().NotBeEmpty();

            ExceptionVerification.ExpectedWarns(1);
        }
    }
}
