using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.ImportLists
{
    public interface IImportListSettings : IProviderConfig
    {
        string BaseUrl { get; set; }
    }
}
