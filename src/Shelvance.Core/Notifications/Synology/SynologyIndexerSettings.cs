using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.ThingiProvider;
using Shelvance.Core.Validation;

namespace Shelvance.Core.Notifications.Synology
{
    public class SynologyIndexerSettingsValidator : AbstractValidator<SynologyIndexerSettings>
    {
    }

    public class SynologyIndexerSettings : IProviderConfig
    {
        private static readonly SynologyIndexerSettingsValidator Validator = new SynologyIndexerSettingsValidator();

        public SynologyIndexerSettings()
        {
            UpdateLibrary = true;
        }

        [FieldDefinition(0, Label = "Update Library", Type = FieldType.Checkbox, HelpText = "Call synoindex on localhost to update a library file")]
        public bool UpdateLibrary { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
