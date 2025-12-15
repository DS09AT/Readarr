using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.ThingiProvider;
using Shelvance.Core.Validation;
using Shelvance.Core.Validation.Paths;

namespace Shelvance.Core.Download.Clients.Pneumatic
{
    public class PneumaticSettingsValidator : AbstractValidator<PneumaticSettings>
    {
        public PneumaticSettingsValidator()
        {
            RuleFor(c => c.NzbFolder).IsValidPath();
            RuleFor(c => c.StrmFolder).IsValidPath();
        }
    }

    public class PneumaticSettings : IProviderConfig
    {
        private static readonly PneumaticSettingsValidator Validator = new PneumaticSettingsValidator();

        [FieldDefinition(0, Label = "Nzb Folder", Type = FieldType.Path, HelpText = "This folder will need to be reachable from XBMC")]
        public string NzbFolder { get; set; }

        [FieldDefinition(1, Label = "Strm Folder", Type = FieldType.Path, HelpText = ".strm files in this folder will be import by drone")]
        public string StrmFolder { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
