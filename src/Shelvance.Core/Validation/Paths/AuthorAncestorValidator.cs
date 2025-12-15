using System.Linq;
using FluentValidation.Validators;
using Shelvance.Common.Extensions;
using Shelvance.Core.Books;

namespace Shelvance.Core.Validation.Paths
{
    public class AuthorAncestorValidator : PropertyValidator
    {
        private readonly IAuthorService _authorService;

        public AuthorAncestorValidator(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        protected override string GetDefaultMessageTemplate() => "Path '{path}' is an ancestor of an existing author";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }

            context.MessageFormatter.AppendArgument("path", context.PropertyValue.ToString());

            return !_authorService.AllAuthorPaths().Any(s => context.PropertyValue.ToString().IsParentPath(s.Value));
        }
    }
}
