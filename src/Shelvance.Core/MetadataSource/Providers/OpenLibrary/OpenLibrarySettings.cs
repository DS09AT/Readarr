using Shelvance.Core.ThingiProvider;
using Shelvance.Core.Validation;

namespace Shelvance.Core.MetadataSource.Providers.OpenLibrary
{
    public class OpenLibrarySettings : IProviderConfig
    {
        public string BaseUrl { get; set; } = "https://openlibrary.org";

        public int RateLimitPerMinute { get; set; } = 100;

        public int RequestTimeoutSeconds { get; set; } = 30;

        public bool UseCoversFallback { get; set; } = true;

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult();
        }
    }
}
