using NUnit.Framework;

namespace Shelvance.Automation.Test
{
    public class AutomationTestAttribute : CategoryAttribute
    {
        public AutomationTestAttribute()
            : base("AutomationTest")
        {
        }
    }
}
