using FluentValidation.Validators;
using Shelvance.Common.Extensions;
using Shelvance.Core.RootFolders;

namespace Shelvance.Core.Validation.Paths
{
    public class RootFolderValidator : PropertyValidator
    {
        private readonly IRootFolderService _rootFolderService;

        public RootFolderValidator(IRootFolderService rootFolderService)
        {
            _rootFolderService = rootFolderService;
        }

        protected override string GetDefaultMessageTemplate() => "Path is already configured as a root folder";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return true;
            }

            return !_rootFolderService.All().Exists(r => r.Path.PathEquals(context.PropertyValue.ToString()));
        }
    }
}
