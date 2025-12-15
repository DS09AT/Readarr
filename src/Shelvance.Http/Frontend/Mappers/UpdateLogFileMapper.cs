using System.IO;
using NLog;
using Shelvance.Common.Disk;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Extensions;

namespace Shelvance.Http.Frontend.Mappers
{
    public class UpdateLogFileMapper : StaticResourceMapperBase
    {
        private readonly IAppFolderInfo _appFolderInfo;

        public UpdateLogFileMapper(IAppFolderInfo appFolderInfo, IDiskProvider diskProvider, Logger logger)
            : base(diskProvider, logger)
        {
            _appFolderInfo = appFolderInfo;
        }

        public override string Map(string resourceUrl)
        {
            var path = resourceUrl.Replace('/', Path.DirectorySeparatorChar);
            path = Path.GetFileName(path);

            return Path.Combine(_appFolderInfo.GetUpdateLogFolder(), path);
        }

        public override bool CanHandle(string resourceUrl)
        {
            return resourceUrl.StartsWith("/updatelogfile/") && resourceUrl.EndsWith(".txt");
        }
    }
}
