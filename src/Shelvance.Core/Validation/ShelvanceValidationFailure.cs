using FluentValidation.Results;

namespace Shelvance.Core.Validation
{
    public class ShelvanceValidationFailure : ValidationFailure
    {
        public bool IsWarning { get; set; }
        public string DetailedDescription { get; set; }
        public string InfoLink { get; set; }

        public ShelvanceValidationFailure(string propertyName, string error)
            : base(propertyName, error)
        {
        }

        public ShelvanceValidationFailure(string propertyName, string error, object attemptedValue)
            : base(propertyName, error, attemptedValue)
        {
        }

        public ShelvanceValidationFailure(ValidationFailure validationFailure)
            : base(validationFailure.PropertyName, validationFailure.ErrorMessage, validationFailure.AttemptedValue)
        {
            CustomState = validationFailure.CustomState;
            var state = validationFailure.CustomState as ShelvanceValidationState;

            IsWarning = state is { IsWarning: true };
        }
    }
}
