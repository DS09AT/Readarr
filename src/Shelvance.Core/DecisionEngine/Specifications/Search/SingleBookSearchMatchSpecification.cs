using System.Linq;
using NLog;
using Shelvance.Core.IndexerSearch.Definitions;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.DecisionEngine.Specifications.Search
{
    public class SingleBookSearchMatchSpecification : IDecisionEngineSpecification
    {
        private readonly Logger _logger;

        public SingleBookSearchMatchSpecification(Logger logger)
        {
            _logger = logger;
        }

        public SpecificationPriority Priority => SpecificationPriority.Default;
        public RejectionType Type => RejectionType.Permanent;

        public virtual Decision IsSatisfiedBy(RemoteBook remoteBook, SearchCriteriaBase searchCriteria)
        {
            if (searchCriteria == null)
            {
                return Decision.Accept();
            }

            var singleBookSpec = searchCriteria as BookSearchCriteria;
            if (singleBookSpec == null)
            {
                return Decision.Accept();
            }

            if (!remoteBook.ParsedBookInfo.BookTitle.Any())
            {
                _logger.Debug("Full discography result during single book search, skipping.");
                return Decision.Reject("Full author pack");
            }

            return Decision.Accept();
        }
    }
}
