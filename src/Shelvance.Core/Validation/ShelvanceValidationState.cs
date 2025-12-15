namespace Shelvance.Core.Validation
{
    public class ShelvanceValidationState
    {
        public static ShelvanceValidationState Warning = new ShelvanceValidationState { IsWarning = true };

        public bool IsWarning { get; set; }
    }
}
