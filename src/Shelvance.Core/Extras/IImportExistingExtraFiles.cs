using System.Collections.Generic;
using Shelvance.Core.Books;
using Shelvance.Core.Extras.Files;

namespace Shelvance.Core.Extras
{
    public interface IImportExistingExtraFiles
    {
        int Order { get; }
        IEnumerable<ExtraFile> ProcessFiles(Author author, List<string> filesOnDisk, List<string> importedFiles);
    }
}
