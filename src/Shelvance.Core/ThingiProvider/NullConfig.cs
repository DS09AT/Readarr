using Shelvance.Core.Validation;

namespace Shelvance.Core.ThingiProvider
{
    public class NullConfig : IProviderConfig
    {
        public static readonly NullConfig Instance = new NullConfig();

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult();
        }
    }
}
