using System.Collections.Generic;
using Shelvance.Core.Extras.Files;

namespace Shelvance.Core.Extras
{
    public class ImportExistingExtraFileFilterResult<TExtraFile>
        where TExtraFile : ExtraFile, new()
    {
        public ImportExistingExtraFileFilterResult(List<TExtraFile> previouslyImported, List<string> filesOnDisk)
        {
            PreviouslyImported = previouslyImported;
            FilesOnDisk = filesOnDisk;
        }

        public List<TExtraFile> PreviouslyImported { get; set; }
        public List<string> FilesOnDisk { get; set; }
    }
}
