using FluentAssertions;
using NUnit.Framework;
using Shelvance.Core.Test.Framework;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.Test.ThingiProviderTests
{
    [TestFixture]
    public class NullConfigFixture : CoreTest<NullConfig>
    {
        [Test]
        public void should_be_valid()
        {
            Subject.Validate().IsValid.Should().BeTrue();
        }
    }
}
