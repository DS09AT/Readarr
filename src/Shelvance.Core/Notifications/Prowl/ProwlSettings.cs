using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.ThingiProvider;
using Shelvance.Core.Validation;

namespace Shelvance.Core.Notifications.Prowl
{
    public class ProwlSettingsValidator : AbstractValidator<ProwlSettings>
    {
        public ProwlSettingsValidator()
        {
            RuleFor(c => c.ApiKey).NotEmpty();
        }
    }

    public class ProwlSettings : IProviderConfig
    {
        private static readonly ProwlSettingsValidator Validator = new ProwlSettingsValidator();

        [FieldDefinition(0, Label = "API Key", Privacy = PrivacyLevel.ApiKey, HelpLink = "https://www.prowlapp.com/api_settings.php")]
        public string ApiKey { get; set; }

        [FieldDefinition(1, Label = "Priority", Type = FieldType.Select, SelectOptions = typeof(ProwlPriority))]
        public int Priority { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(ApiKey) && Priority >= -2 && Priority <= 2;

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
