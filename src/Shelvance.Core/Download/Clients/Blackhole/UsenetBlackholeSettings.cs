using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.ThingiProvider;
using Shelvance.Core.Validation;
using Shelvance.Core.Validation.Paths;

namespace Shelvance.Core.Download.Clients.Blackhole
{
    public class UsenetBlackholeSettingsValidator : AbstractValidator<UsenetBlackholeSettings>
    {
        public UsenetBlackholeSettingsValidator()
        {
            RuleFor(c => c.NzbFolder).IsValidPath();
            RuleFor(c => c.WatchFolder).IsValidPath();
        }
    }

    public class UsenetBlackholeSettings : IProviderConfig
    {
        private static readonly UsenetBlackholeSettingsValidator Validator = new UsenetBlackholeSettingsValidator();

        [FieldDefinition(0, Label = "Nzb Folder", Type = FieldType.Path, HelpText = "Folder in which Shelvance will store the .nzb file")]
        public string NzbFolder { get; set; }

        [FieldDefinition(1, Label = "Watch Folder", Type = FieldType.Path, HelpText = "Folder from which Shelvance should import completed downloads")]
        public string WatchFolder { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
