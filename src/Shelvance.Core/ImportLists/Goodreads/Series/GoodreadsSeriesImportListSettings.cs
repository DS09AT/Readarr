using FluentValidation;
using Shelvance.Core.Annotations;
using Shelvance.Core.Validation;

namespace Shelvance.Core.ImportLists.Goodreads
{
    public class GoodreadsSeriesImportListValidator : AbstractValidator<GoodreadsSeriesImportListSettings>
    {
        public GoodreadsSeriesImportListValidator()
        {
            RuleFor(c => c.SeriesId).GreaterThan(0);
        }
    }

    public class GoodreadsSeriesImportListSettings : IImportListSettings
    {
        private static readonly GoodreadsSeriesImportListValidator Validator = new ();

        public GoodreadsSeriesImportListSettings()
        {
            BaseUrl = "www.goodreads.com";
        }

        public string BaseUrl { get; set; }

        [FieldDefinition(0, Label = "Series ID", HelpText = "Goodreads series ID")]
        public int SeriesId { get; set; }

        public ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
