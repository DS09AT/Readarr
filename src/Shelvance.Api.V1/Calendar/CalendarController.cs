using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shelvance.Core.AuthorStats;
using Shelvance.Core.Books;
using Shelvance.Core.DecisionEngine.Specifications;
using Shelvance.Core.MediaCover;
using Shelvance.SignalR;
using Shelvance.Api.V1.Books;
using Shelvance.Http;
using Shelvance.Http.Extensions;

namespace Shelvance.Api.V1.Calendar
{
    [V1ApiController]
    public class CalendarController : BookControllerWithSignalR
    {
        public CalendarController(IBookService bookService,
                              ISeriesBookLinkService seriesBookLinkService,
                              IAuthorStatisticsService authorStatisticsService,
                              IMapCoversToLocal coverMapper,
                              IUpgradableSpecification upgradableSpecification,
                              IBroadcastSignalRMessage signalRBroadcaster)
        : base(bookService, seriesBookLinkService, authorStatisticsService, coverMapper, upgradableSpecification, signalRBroadcaster)
        {
        }

        [HttpGet]
        public List<BookResource> GetCalendar(DateTime? start, DateTime? end, bool unmonitored = false, bool includeAuthor = false)
        {
            //TODO: Add Book Image support to BookControllerWithSignalR
            var includeBookImages = Request.GetBooleanQueryParameter("includeBookImages");

            var startUse = start ?? DateTime.Today;
            var endUse = end ?? DateTime.Today.AddDays(2);

            var resources = MapToResource(_bookService.BooksBetweenDates(startUse, endUse, unmonitored), includeAuthor);

            return resources.OrderBy(e => e.ReleaseDate).ToList();
        }
    }
}
