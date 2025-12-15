using NLog;
using Shelvance.Common.Instrumentation.Extensions;
using Shelvance.Core.Download;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.IndexerSearch
{
    public class AuthorSearchService : IExecute<AuthorSearchCommand>
    {
        private readonly ISearchForReleases _releaseSearchService;
        private readonly IProcessDownloadDecisions _processDownloadDecisions;
        private readonly Logger _logger;

        public AuthorSearchService(ISearchForReleases releaseSearchService,
            IProcessDownloadDecisions processDownloadDecisions,
            Logger logger)
        {
            _releaseSearchService = releaseSearchService;
            _processDownloadDecisions = processDownloadDecisions;
            _logger = logger;
        }

        public void Execute(AuthorSearchCommand message)
        {
            var decisions = _releaseSearchService.AuthorSearch(message.AuthorId, false, message.Trigger == CommandTrigger.Manual, false).GetAwaiter().GetResult();
            var processed = _processDownloadDecisions.ProcessDecisions(decisions).GetAwaiter().GetResult();

            _logger.ProgressInfo("Author search completed. {0} reports downloaded.", processed.Grabbed.Count);
        }
    }
}
