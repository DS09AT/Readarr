using Shelvance.Common.Disk;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Extensions;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class CleanupTemporaryUpdateFiles : IHousekeepingTask
    {
        private readonly IDiskProvider _diskProvider;
        private readonly IAppFolderInfo _appFolderInfo;

        public CleanupTemporaryUpdateFiles(IDiskProvider diskProvider, IAppFolderInfo appFolderInfo)
        {
            _diskProvider = diskProvider;
            _appFolderInfo = appFolderInfo;
        }

        public void Clean()
        {
            var updateSandboxFolder = _appFolderInfo.GetUpdateSandboxFolder();

            if (_diskProvider.FolderExists(updateSandboxFolder))
            {
                _diskProvider.DeleteFolder(updateSandboxFolder, true);
            }
        }
    }
}
