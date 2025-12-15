using System;
using Microsoft.AspNetCore.Mvc;
using NzbDrone.Core.Extras.Metadata;
using Readarr.Http;

namespace Readarr.Api.V1.Metadata
{
    [V1ApiController]
    public class MetadataFilesController : ProviderControllerBase<MetadataResource, MetadataBulkResource, IMetadata, MetadataDefinition>
    {
        public static readonly MetadataResourceMapper ResourceMapper = new ();
        public static readonly MetadataBulkResourceMapper BulkResourceMapper = new ();

        public MetadataFilesController(IMetadataFactory metadataFactory)
            : base(metadataFactory, "metadatafiles", ResourceMapper, BulkResourceMapper)
        {
        }

        [NonAction]
        public override ActionResult<MetadataResource> UpdateProvider([FromBody] MetadataBulkResource providerResource)
        {
            throw new NotImplementedException();
        }

        [NonAction]
        public override object DeleteProviders([FromBody] MetadataBulkResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
