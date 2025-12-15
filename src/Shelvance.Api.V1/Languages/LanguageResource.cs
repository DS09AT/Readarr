using System.Text.Json.Serialization;
using Shelvance.Http.REST;

namespace Shelvance.Api.V1.Languages
{
    public class LanguageResource : RestResource
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public new int Id { get; set; }
        public string Name { get; set; }
        public string NameLower => Name.ToLowerInvariant();
    }
}
