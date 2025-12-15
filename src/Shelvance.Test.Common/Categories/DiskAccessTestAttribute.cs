using NUnit.Framework;

namespace Shelvance.Test.Common.Categories
{
    public class DiskAccessTestAttribute : CategoryAttribute
    {
        public DiskAccessTestAttribute()
            : base("DiskAccessTest")
        {
        }
    }
}
