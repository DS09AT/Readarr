using Shelvance.Core.Datastore;

namespace Shelvance.Core.CustomFilters
{
    public class CustomFilter : ModelBase
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string Filters { get; set; }
    }
}
