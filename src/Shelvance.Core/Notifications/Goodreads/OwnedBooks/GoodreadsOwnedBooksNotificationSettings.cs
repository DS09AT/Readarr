using Shelvance.Core.Annotations;
using Shelvance.Core.Validation;

namespace Shelvance.Core.Notifications.Goodreads
{
    public enum OwnedBookCondition
    {
        BrandNew = 10,
        LikeNew = 20,
        VeryGood = 30,
        Good = 40,
        Acceptable = 50,
        Poor = 60
    }

    public class GoodreadsOwnedBooksNotificationSettings : GoodreadsSettingsBase<GoodreadsOwnedBooksNotificationSettings>
    {
        private static readonly GoodreadsSettingsBaseValidator<GoodreadsOwnedBooksNotificationSettings> Validator = new GoodreadsSettingsBaseValidator<GoodreadsOwnedBooksNotificationSettings>();

        [FieldDefinition(1, Label = "Condition", Type = FieldType.Select, SelectOptions = typeof(OwnedBookCondition))]
        public int Condition { get; set; } = (int)OwnedBookCondition.BrandNew;

        [FieldDefinition(1, Label = "Condition Description", Type = FieldType.Textbox)]
        public string Description { get; set; }

        [FieldDefinition(1, Label = "Purchase Location", HelpText = "Will be displayed on Goodreads website", Type = FieldType.Textbox)]
        public string Location { get; set; }

        public override ShelvanceValidationResult Validate()
        {
            return new ShelvanceValidationResult(Validator.Validate(this));
        }
    }
}
