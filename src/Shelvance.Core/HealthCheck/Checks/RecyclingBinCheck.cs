using Shelvance.Common.Disk;
using Shelvance.Common.Extensions;
using Shelvance.Core.Configuration;
using Shelvance.Core.Localization;
using Shelvance.Core.MediaFiles.Events;

namespace Shelvance.Core.HealthCheck.Checks
{
    [CheckOn(typeof(BookImportedEvent), CheckOnCondition.FailedOnly)]
    [CheckOn(typeof(TrackImportedEvent), CheckOnCondition.FailedOnly)]
    [CheckOn(typeof(TrackImportFailedEvent), CheckOnCondition.SuccessfulOnly)]
    public class RecyclingBinCheck : HealthCheckBase
    {
        private readonly IConfigService _configService;
        private readonly IDiskProvider _diskProvider;

        public RecyclingBinCheck(IConfigService configService, IDiskProvider diskProvider, ILocalizationService localizationService)
            : base(localizationService)
        {
            _configService = configService;
            _diskProvider = diskProvider;
        }

        public override HealthCheck Check()
        {
            var recycleBin = _configService.RecycleBin;

            if (recycleBin.IsNullOrWhiteSpace())
            {
                return new HealthCheck(GetType());
            }

            if (!_diskProvider.FolderWritable(recycleBin))
            {
                return new HealthCheck(GetType(), HealthCheckResult.Error, string.Format(_localizationService.GetLocalizedString("RecycleBinUnableToWriteHealthCheck"), recycleBin), "#cannot-write-recycle-bin");
            }

            return new HealthCheck(GetType());
        }
    }
}
