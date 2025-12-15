using System.Text.Json.Serialization;

namespace Shelvance.Core.MetadataSource.Providers.OpenLibrary.Resources
{
    public class OpenLibraryAuthorRefResource
    {
        [JsonPropertyName("author")]
        public OpenLibraryKeyResource Author { get; set; }

        public string GetAuthorId()
        {
            if (Author?.Key == null)
            {
                return null;
            }

            return Author.Key.Replace("/authors/", "");
        }
    }
}
