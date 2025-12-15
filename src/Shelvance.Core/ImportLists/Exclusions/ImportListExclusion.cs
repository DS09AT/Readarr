using Shelvance.Core.Datastore;

namespace Shelvance.Core.ImportLists.Exclusions
{
    public class ImportListExclusion : ModelBase
    {
        public string ForeignId { get; set; }
        public string Name { get; set; }
    }
}
