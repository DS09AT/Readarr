using System.Linq;
using NLog;
using Shelvance.Core.IndexerSearch.Definitions;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.DecisionEngine.Specifications.Search
{
    public class BookRequestedSpecification : IDecisionEngineSpecification
    {
        private readonly Logger _logger;

        public BookRequestedSpecification(Logger logger)
        {
            _logger = logger;
        }

        public SpecificationPriority Priority => SpecificationPriority.Default;
        public RejectionType Type => RejectionType.Permanent;

        public Decision IsSatisfiedBy(RemoteBook remoteBook, SearchCriteriaBase searchCriteria)
        {
            if (searchCriteria == null)
            {
                return Decision.Accept();
            }

            var criteriaBook = searchCriteria.Books.Select(v => v.Id).ToList();
            var remoteBooks = remoteBook.Books.Select(v => v.Id).ToList();

            if (!criteriaBook.Intersect(remoteBooks).Any())
            {
                _logger.Debug("Release rejected since the book wasn't requested: {0}", remoteBook.ParsedBookInfo);
                return Decision.Reject("Book wasn't requested");
            }

            return Decision.Accept();
        }
    }
}
