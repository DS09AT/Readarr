using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace Shelvance.Core.Validation
{
    public static class ShelvanceValidationExtensions
    {
        public static ShelvanceValidationResult Filter(this ShelvanceValidationResult result, params string[] fields)
        {
            var failures = result.Failures.Where(v => fields.Contains(v.PropertyName)).ToArray();

            return new ShelvanceValidationResult(failures);
        }

        public static void ThrowOnError(this ShelvanceValidationResult result)
        {
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        public static bool HasErrors(this List<ValidationFailure> list)
        {
            return list.Any(item => item is not ShelvanceValidationFailure { IsWarning: true });
        }
    }
}
