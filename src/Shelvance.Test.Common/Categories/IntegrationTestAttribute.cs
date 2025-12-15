using NUnit.Framework;

namespace Shelvance.Test.Common.Categories
{
    public class IntegrationTestAttribute : CategoryAttribute
    {
        public IntegrationTestAttribute()
            : base("IntegrationTest")
        {
        }
    }
}
