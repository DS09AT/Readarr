using System;
using Moq;
using NUnit.Framework;
using Shelvance.Common;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Extensions;
using Shelvance.Common.Processes;
using Shelvance.Test.Common;
using Shelvance.Update.UpdateEngine;
using IServiceProvider = Shelvance.Common.IServiceProvider;

namespace Shelvance.Update.Test
{
    [TestFixture]
    public class StartShelvanceServiceFixture : TestBase<StartShelvance>
    {
        [Test]
        public void should_start_service_if_app_type_was_serivce()
        {
            var targetFolder = "c:\\Shelvance\\".AsOsAgnostic();

            Subject.Start(AppType.Service, targetFolder);

            Mocker.GetMock<IServiceProvider>().Verify(c => c.Start(ServiceProvider.SERVICE_NAME), Times.Once());
        }

        [Test]
        public void should_start_console_if_app_type_was_service_but_start_failed_because_of_permissions()
        {
            var targetFolder = "c:\\Shelvance\\".AsOsAgnostic();
            var targetProcess = "c:\\Shelvance\\Shelvance.Console".AsOsAgnostic().ProcessNameToExe();

            Mocker.GetMock<IServiceProvider>().Setup(c => c.Start(ServiceProvider.SERVICE_NAME)).Throws(new InvalidOperationException());

            Subject.Start(AppType.Service, targetFolder);

            Mocker.GetMock<IProcessProvider>().Verify(c => c.SpawnNewProcess(targetProcess, "/" + StartupContext.NO_BROWSER, null, false), Times.Once());

            ExceptionVerification.ExpectedWarns(1);
        }
    }
}
