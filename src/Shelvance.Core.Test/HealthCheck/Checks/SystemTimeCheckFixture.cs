using System;
using System.Text;
using Moq;
using NUnit.Framework;
using Shelvance.Common.Cloud;
using Shelvance.Common.Http;
using Shelvance.Common.Serializer;
using Shelvance.Core.HealthCheck.Checks;
using Shelvance.Core.Localization;
using Shelvance.Core.Test.Framework;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.HealthCheck.Checks
{
    [TestFixture]
    public class SystemTimeCheckFixture : CoreTest<SystemTimeCheck>
    {
        [SetUp]
        public void Setup()
        {
            Mocker.SetConstant<IShelvanceCloudRequestBuilder>(new ShelvanceCloudRequestBuilder());
        }

        private void GivenServerTime(DateTime dateTime)
        {
            var json = new ServiceTimeResponse { DateTimeUtc = dateTime }.ToJson();

            Mocker.GetMock<ILocalizationService>()
                  .Setup(s => s.GetLocalizedString(It.IsAny<string>()))
                  .Returns("System time is off by more than 1 day. Scheduled tasks may not run correctly until the time is corrected");

            Mocker.GetMock<IHttpClient>()
                  .Setup(s => s.Execute(It.IsAny<HttpRequest>()))
                  .Returns<HttpRequest>(r => new HttpResponse(r, new HttpHeader(), Encoding.ASCII.GetBytes(json)));
        }

        [Test]
        public void should_not_return_error_when_system_time_is_close_to_server_time()
        {
            GivenServerTime(DateTime.UtcNow);

            Subject.Check().ShouldBeOk();
        }

        [Test]
        public void should_return_error_when_system_time_is_more_than_one_day_from_server_time()
        {
            GivenServerTime(DateTime.UtcNow.AddDays(2));

            Subject.Check().ShouldBeError();
            ExceptionVerification.ExpectedErrors(1);
        }
    }
}
