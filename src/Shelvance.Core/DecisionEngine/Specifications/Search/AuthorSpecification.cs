using NLog;
using Shelvance.Core.IndexerSearch.Definitions;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.DecisionEngine.Specifications.Search
{
    public class AuthorSpecification : IDecisionEngineSpecification
    {
        private readonly Logger _logger;

        public AuthorSpecification(Logger logger)
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

            _logger.Debug("Checking if author matches searched author");

            if (remoteBook.Author.Id != searchCriteria.Author.Id)
            {
                _logger.Debug("Author {0} does not match {1}", remoteBook.Author, searchCriteria.Author);
                return Decision.Reject("Wrong author");
            }

            return Decision.Accept();
        }
    }
}
