using FluentAssertions;
using NUnit.Framework;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Processes;
using Shelvance.Mono.EnvironmentInfo.VersionAdapters;
using Shelvance.Test.Common;

namespace Shelvance.Mono.Test.EnvironmentInfo
{
    [TestFixture]
    [Platform("Linux")]
    public class FreebsdVersionAdapterFixture : TestBase<FreebsdVersionAdapter>
    {
        [SetUp]
        public void Setup()
        {
            if (OsInfo.Os != Os.Bsd)
            {
                throw new IgnoreException("BSD Only");
            }

            Mocker.SetConstant<IProcessProvider>(Mocker.Resolve<ProcessProvider>());
        }

        [Test]
        public void should_get_version_info()
        {
            var info = Subject.Read();
            info.FullName.Should().NotBeNullOrWhiteSpace();
            info.Name.Should().NotBeNullOrWhiteSpace();
            info.Version.Should().NotBeNullOrWhiteSpace();
        }
    }
}
