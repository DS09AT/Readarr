using Moq;
using NUnit.Framework;
using Shelvance.Common.Disk;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Core.Configuration;
using Shelvance.Core.HealthCheck.Checks;
using Shelvance.Core.Localization;
using Shelvance.Core.Test.Framework;
using Shelvance.Core.Update;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.HealthCheck.Checks
{
    [TestFixture]
    public class UpdateCheckFixture : CoreTest<UpdateCheck>
    {
        [SetUp]
        public void Setup()
        {
            Mocker.GetMock<ILocalizationService>()
                  .Setup(s => s.GetLocalizedString(It.IsAny<string>()))
                  .Returns("Some Warning Message");
        }

        [Test]
        public void should_return_error_when_app_folder_is_write_protected_and_update_automatically_is_enabled()
        {
            var startupFolder = @"C:\Shelvance".AsOsAgnostic();

            Mocker.GetMock<IConfigFileProvider>()
                  .Setup(s => s.UpdateAutomatically)
                  .Returns(true);

            Mocker.GetMock<IAppFolderInfo>()
                  .Setup(s => s.StartUpFolder)
                  .Returns(startupFolder);

            Mocker.GetMock<IDiskProvider>()
                  .Setup(c => c.FolderWritable(startupFolder))
                  .Returns(false);

            Subject.Check().ShouldBeError();
        }

        [Test]
        public void should_return_error_when_ui_folder_is_write_protected_and_update_automatically_is_enabled()
        {
            var startupFolder = @"C:\Shelvance".AsOsAgnostic();
            var uiFolder = @"C:\Shelvance\UI".AsOsAgnostic();

            Mocker.GetMock<IConfigFileProvider>()
                  .Setup(s => s.UpdateAutomatically)
                  .Returns(true);

            Mocker.GetMock<IAppFolderInfo>()
                  .Setup(s => s.StartUpFolder)
                  .Returns(startupFolder);

            Mocker.GetMock<IDiskProvider>()
                  .Setup(c => c.FolderWritable(startupFolder))
                  .Returns(true);

            Mocker.GetMock<IDiskProvider>()
                  .Setup(c => c.FolderWritable(uiFolder))
                  .Returns(false);

            Subject.Check().ShouldBeError();
        }

        [Test]
        public void should_not_return_error_when_app_folder_is_write_protected_and_external_script_enabled()
        {
            var startupFolder = @"C:\Shelvance".AsOsAgnostic();

            Mocker.GetMock<IConfigFileProvider>()
                  .Setup(s => s.UpdateAutomatically)
                  .Returns(true);

            Mocker.GetMock<IConfigFileProvider>()
                  .Setup(s => s.UpdateMechanism)
                  .Returns(UpdateMechanism.Script);

            Mocker.GetMock<IAppFolderInfo>()
                  .Setup(s => s.StartUpFolder)
                  .Returns(startupFolder);

            Mocker.GetMock<IDiskProvider>()
                  .Verify(c => c.FolderWritable(It.IsAny<string>()), Times.Never());

            Subject.Check().ShouldBeOk();
        }
    }
}
