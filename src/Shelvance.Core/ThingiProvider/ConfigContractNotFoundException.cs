using Shelvance.Common.Exceptions;

namespace Shelvance.Core.ThingiProvider
{
    public class ConfigContractNotFoundException : ShelvanceException
    {
        public ConfigContractNotFoundException(string contract)
            : base("Couldn't find config contract " + contract)
        {
        }
    }
}
