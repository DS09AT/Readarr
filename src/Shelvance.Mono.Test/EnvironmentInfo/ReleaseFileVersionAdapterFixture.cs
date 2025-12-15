using System.IO.Abstractions;
using FluentAssertions;
using NUnit.Framework;
using Shelvance.Common.Disk;
using Shelvance.Mono.Disk;
using Shelvance.Mono.EnvironmentInfo.VersionAdapters;
using Shelvance.Test.Common;

namespace Shelvance.Mono.Test.EnvironmentInfo
{
    [TestFixture]
    [Platform("Linux")]
    public class ReleaseFileVersionAdapterFixture : TestBase<ReleaseFileVersionAdapter>
    {
        [SetUp]
        public void Setup()
        {
            NotBsd();

            Mocker.SetConstant<IFileSystem>(new FileSystem());
            Mocker.SetConstant<IDiskProvider>(Mocker.Resolve<DiskProvider>());
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
