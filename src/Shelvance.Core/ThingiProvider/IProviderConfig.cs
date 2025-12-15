using Shelvance.Core.Validation;

namespace Shelvance.Core.ThingiProvider
{
    public interface IProviderConfig
    {
        ShelvanceValidationResult Validate();
    }
}
