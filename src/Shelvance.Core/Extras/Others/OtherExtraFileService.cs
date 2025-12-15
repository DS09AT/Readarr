using NLog;
using Shelvance.Common.Disk;
using Shelvance.Core.Books;
using Shelvance.Core.Extras.Files;
using Shelvance.Core.MediaFiles;

namespace Shelvance.Core.Extras.Others
{
    public interface IOtherExtraFileService : IExtraFileService<OtherExtraFile>
    {
    }

    public class OtherExtraFileService : ExtraFileService<OtherExtraFile>, IOtherExtraFileService
    {
        public OtherExtraFileService(IExtraFileRepository<OtherExtraFile> repository, IAuthorService authorService, IDiskProvider diskProvider, IRecycleBinProvider recycleBinProvider, Logger logger)
            : base(repository, authorService, diskProvider, recycleBinProvider, logger)
        {
        }
    }
}
