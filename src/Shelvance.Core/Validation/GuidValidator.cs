using System;
using FluentValidation.Validators;

namespace Shelvance.Core.Validation
{
    public class GuidValidator : PropertyValidator
    {
        protected override string GetDefaultMessageTemplate() => "String is not a valid Guid";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return false;
            }

            return Guid.TryParse(context.PropertyValue.ToString(), out _);
        }
    }
}
