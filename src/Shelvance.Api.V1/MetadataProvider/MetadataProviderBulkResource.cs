using System.Collections.Generic;
using Shelvance.Core.MetadataSource;

namespace Shelvance.Api.V1.MetadataProvider
{
    public class MetadataProviderBulkResource : ProviderBulkResource<MetadataProviderBulkResource>
    {
        public bool? EnableAuthorSearch { get; set; }
        public bool? EnableBookSearch { get; set; }
        public bool? EnableAutomaticRefresh { get; set; }
        public int? Priority { get; set; }
    }

    public class MetadataProviderBulkResourceMapper : ProviderBulkResourceMapper<MetadataProviderBulkResource, MetadataProviderDefinition>
    {
        public override List<MetadataProviderDefinition> UpdateModel(MetadataProviderBulkResource resource, List<MetadataProviderDefinition> existingDefinitions)
        {
            if (resource == null)
            {
                return new List<MetadataProviderDefinition>();
            }

            existingDefinitions.ForEach(existing =>
            {
                existing.EnableAuthorSearch = resource.EnableAuthorSearch ?? existing.EnableAuthorSearch;
                existing.EnableBookSearch = resource.EnableBookSearch ?? existing.EnableBookSearch;
                existing.EnableAutomaticRefresh = resource.EnableAutomaticRefresh ?? existing.EnableAutomaticRefresh;
                existing.Priority = resource.Priority ?? existing.Priority;
            });

            return existingDefinitions;
        }
    }
}
