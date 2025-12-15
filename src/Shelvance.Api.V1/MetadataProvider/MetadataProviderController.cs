using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using NzbDrone.Core.MetadataSource;
using Shelvance.Http;

namespace Shelvance.Api.V1.MetadataProvider
{
    [V1ApiController]
    public class MetadataProviderController : ProviderControllerBase<MetadataProviderResource, MetadataProviderBulkResource, IMetadataProvider, MetadataProviderDefinition>
    {
        public static readonly MetadataProviderResourceMapper ResourceMapper = new ();
        public static readonly MetadataProviderBulkResourceMapper BulkResourceMapper = new ();

        private readonly IMetadataProviderFactory _metadataProviderFactory;

        public MetadataProviderController(IMetadataProviderFactory metadataProviderFactory)
            : base(metadataProviderFactory, "metadataprovider", ResourceMapper, BulkResourceMapper)
        {
            _metadataProviderFactory = metadataProviderFactory;

            // Priority validation: 1-100
            SharedValidator.RuleFor(c => c.Priority).InclusiveBetween(1, 100);
        }

        public override List<MetadataProviderResource> GetTemplates()
        {
            var templates = base.GetTemplates();

            // Populate capabilities for each template from the provider definitions
            foreach (var template in templates)
            {
                var definition = _metadataProviderFactory.GetDefaultDefinitions()
                    .FirstOrDefault(d => d.Implementation == template.Implementation);

                if (definition != null)
                {
                    var provider = _metadataProviderFactory.GetInstance(definition);

                    template.InfoLink = provider.InfoLink;
                    template.SupportsAuthorSearch = provider.Capabilities.SupportsAuthorSearch;
                    template.SupportsBookSearch = provider.Capabilities.SupportsBookSearch;
                    template.SupportsIsbnLookup = provider.Capabilities.SupportsIsbnLookup;
                    template.SupportsAsinLookup = provider.Capabilities.SupportsAsinLookup;
                    template.SupportsSeriesInfo = provider.Capabilities.SupportsSeriesInfo;
                    template.SupportsChangeFeed = provider.Capabilities.SupportsChangeFeed;
                    template.SupportsCovers = provider.Capabilities.SupportsCovers;
                    template.SupportsRatings = provider.Capabilities.SupportsRatings;
                    template.SupportsDescriptions = provider.Capabilities.SupportsDescriptions;
                }
            }

            return templates;
        }

        protected override MetadataProviderResource GetResourceById(int id)
        {
            var resource = base.GetResourceById(id);

            // Populate capabilities from provider instance
            var provider = _metadataProviderFactory.GetAvailableProviders()
                .FirstOrDefault(p => p.Definition.Id == id);

            if (provider != null)
            {
                resource.InfoLink = provider.InfoLink;
                resource.SupportsAuthorSearch = provider.Capabilities.SupportsAuthorSearch;
                resource.SupportsBookSearch = provider.Capabilities.SupportsBookSearch;
                resource.SupportsIsbnLookup = provider.Capabilities.SupportsIsbnLookup;
                resource.SupportsAsinLookup = provider.Capabilities.SupportsAsinLookup;
                resource.SupportsSeriesInfo = provider.Capabilities.SupportsSeriesInfo;
                resource.SupportsChangeFeed = provider.Capabilities.SupportsChangeFeed;
                resource.SupportsCovers = provider.Capabilities.SupportsCovers;
                resource.SupportsRatings = provider.Capabilities.SupportsRatings;
                resource.SupportsDescriptions = provider.Capabilities.SupportsDescriptions;
            }

            return resource;
        }
    }
}
