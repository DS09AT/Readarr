using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.ThingiProvider;
using Shelvance.Core.Validation;
using Shelvance.Core.Validation.Paths;

namespace Shelvance.Core.Notifications.CustomScript
{
    public class CustomScriptSettingsValidator : AbstractValidator<CustomScriptSettings>
    {
        public CustomScriptSettingsValidator()
        {
            RuleFor(c => c.Path).IsValidPath();
            RuleFor(c => c.Path).SetValidator(new SystemFolderValidator()).WithMessage("Must not be a descendant of '{systemFolder}'");
            RuleFor(c => c.Arguments).Empty().WithMessage("Arguments are no longer supported for custom scripts");
        }
    }

    public class CustomScriptSettings : IProviderConfig
    {
        private static readonly CustomScriptSettingsValidator Validator = new CustomScriptSettingsValidator();

        [FieldDefinition(0, Label = "Path", Type = FieldType.FilePath)]
        public string Path { get; set; }

        [FieldDefinition(1, Label = "Arguments", HelpText = "Arguments to pass to the script", Hidden = HiddenType.HiddenIfNotSet)]
        public string Arguments { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
