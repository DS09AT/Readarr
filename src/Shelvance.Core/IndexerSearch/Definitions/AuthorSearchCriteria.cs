namespace Shelvance.Core.IndexerSearch.Definitions
{
    public class AuthorSearchCriteria : SearchCriteriaBase
    {
        public override string ToString()
        {
            return $"[{Author.Name}]";
        }
    }
}
