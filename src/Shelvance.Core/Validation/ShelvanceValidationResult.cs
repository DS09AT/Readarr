using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Shelvance.Common.Extensions;

namespace Shelvance.Core.Validation
{
    public class ShelvanceValidationResult : ValidationResult
    {
        public ShelvanceValidationResult()
        {
            Failures = new List<ShelvanceValidationFailure>();
            Errors = new List<ShelvanceValidationFailure>();
            Warnings = new List<ShelvanceValidationFailure>();
        }

        public ShelvanceValidationResult(ValidationResult validationResult)
            : this(validationResult.Errors)
        {
        }

        public ShelvanceValidationResult(IEnumerable<ValidationFailure> failures)
        {
            var errors = new List<ShelvanceValidationFailure>();
            var warnings = new List<ShelvanceValidationFailure>();

            foreach (var failureBase in failures)
            {
                if (failureBase is not ShelvanceValidationFailure failure)
                {
                    failure = new ShelvanceValidationFailure(failureBase);
                }

                if (failure.IsWarning)
                {
                    warnings.Add(failure);
                }
                else
                {
                    errors.Add(failure);
                }
            }

            Failures = errors.Concat(warnings).ToList();
            Errors = errors;
            errors.ForEach(base.Errors.Add);
            Warnings = warnings;
        }

        public IList<ShelvanceValidationFailure> Failures { get; private set; }
        public new IList<ShelvanceValidationFailure> Errors { get; private set; }
        public IList<ShelvanceValidationFailure> Warnings { get; private set; }

        public virtual bool HasWarnings => Warnings.Any();

        public override bool IsValid => Errors.Empty();
    }
}
