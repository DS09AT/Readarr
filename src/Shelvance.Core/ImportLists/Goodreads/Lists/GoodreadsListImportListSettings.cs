using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.Validation;

namespace Shelvance.Core.ImportLists.Goodreads
{
    public class GoodreadsListImportListValidator : AbstractValidator<GoodreadsListImportListSettings>
    {
        public GoodreadsListImportListValidator()
        {
            RuleFor(c => c.ListId).GreaterThan(0);
        }
    }

    public class GoodreadsListImportListSettings : IImportListSettings
    {
        private static readonly GoodreadsListImportListValidator Validator = new ();

        public GoodreadsListImportListSettings()
        {
            BaseUrl = "www.goodreads.com";
        }

        public string BaseUrl { get; set; }

        [FieldDefinition(0, Label = "List ID", HelpText = "Goodreads list ID")]
        public int ListId { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
