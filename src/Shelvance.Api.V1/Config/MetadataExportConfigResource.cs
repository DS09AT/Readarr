using Shelvance.Core.Configuration;
using Shelvance.Http.REST;

namespace Shelvance.Api.V1.Config
{
    public class MetadataExportConfigResource : RestResource
    {
        public WriteAudioTagsType WriteAudioTags { get; set; }
        public bool ScrubAudioTags { get; set; }
        public WriteBookTagsType WriteBookTags { get; set; }
        public bool UpdateCovers { get; set; }
        public bool EmbedMetadata { get; set; }
    }

    public static class MetadataExportConfigResourceMapper
    {
        public static MetadataExportConfigResource ToResource(IConfigService model)
        {
            return new MetadataExportConfigResource
            {
                WriteAudioTags = model.WriteAudioTags,
                ScrubAudioTags = model.ScrubAudioTags,
                WriteBookTags = model.WriteBookTags,
                UpdateCovers = model.UpdateCovers,
                EmbedMetadata = model.EmbedMetadata
            };
        }
    }
}
