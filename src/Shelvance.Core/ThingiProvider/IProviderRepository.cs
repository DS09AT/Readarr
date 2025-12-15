using Shelvance.Core.Datastore;

namespace Shelvance.Core.ThingiProvider
{
    public interface IProviderRepository<TProvider> : IBasicRepository<TProvider>
        where TProvider : ModelBase, new()
    {
        //        void DeleteImplementations(string implementation);
    }
}
