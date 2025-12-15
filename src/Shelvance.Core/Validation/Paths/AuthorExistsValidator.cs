using FluentValidation.Validators;
using Shelvance.Core.Books;

namespace Shelvance.Core.Validation.Paths
{
    public class AuthorExistsValidator : PropertyValidator
    {
        private readonly IAuthorService _authorService;

        public AuthorExistsValidator(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        protected override string GetDefaultMessageTemplate() => "This author has already been added";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }

            var foreignAuthorId = context.PropertyValue.ToString();

            return _authorService.FindById(foreignAuthorId) == null;
        }
    }
}
