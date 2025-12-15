using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.Validation;

namespace Shelvance.Core.ImportLists.LazyLibrarianImport
{
    public class LazyLibrarianImportSettingsValidator : AbstractValidator<LazyLibrarianImportSettings>
    {
        public LazyLibrarianImportSettingsValidator()
        {
            RuleFor(c => c.BaseUrl).IsValidUrl();
            RuleFor(c => c.ApiKey).NotEmpty();
        }
    }

    public class LazyLibrarianImportSettings : IImportListSettings
    {
        private static readonly LazyLibrarianImportSettingsValidator Validator = new LazyLibrarianImportSettingsValidator();

        public LazyLibrarianImportSettings()
        {
            BaseUrl = "http://localhost:5299";
        }

        [FieldDefinition(0, Label = "Url")]
        public string BaseUrl { get; set; }

        [FieldDefinition(1, Label = "API Key")]
        public string ApiKey { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
