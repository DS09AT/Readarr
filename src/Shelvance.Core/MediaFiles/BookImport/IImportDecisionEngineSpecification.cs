using Shelvance.Core.DecisionEngine;
using Shelvance.Core.Download;

namespace Shelvance.Core.MediaFiles.BookImport
{
    public interface IImportDecisionEngineSpecification<T>
    {
        Decision IsSatisfiedBy(T item, DownloadClientItem downloadClientItem);
    }
}
