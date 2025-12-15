using NzbDrone.Core.Configuration;
using Readarr.Http;

namespace Readarr.Api.V1.Config
{
    [V1ApiController("config/metadataexport")]
    public class MetadataExportConfigController : ConfigController<MetadataExportConfigResource>
    {
        public MetadataExportConfigController(IConfigService configService)
            : base(configService)
        {
        }

        protected override MetadataExportConfigResource ToResource(IConfigService model)
        {
            return MetadataExportConfigResourceMapper.ToResource(model);
        }
    }
}
