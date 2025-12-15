using System.Text.Json.Serialization;

namespace Shelvance.Core.MetadataSource.Providers.OpenLibrary.Resources
{
    public class OpenLibraryLanguageRefResource
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        public string GetLanguageCode()
        {
            if (string.IsNullOrEmpty(Key))
            {
                return null;
            }

            return Key.Replace("/languages/", "");
        }
    }
}
