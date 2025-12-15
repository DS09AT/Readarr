using System;
using Moq;
using NUnit.Framework;
using Shelvance.Common.Cache;
using Shelvance.Common.Cloud;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Http;
using Shelvance.Common.Http.Dispatchers;
using Shelvance.Common.Http.Proxy;
using Shelvance.Common.TPL;
using Shelvance.Core.Configuration;
using Shelvance.Core.Http;
using Shelvance.Core.MetadataSource;
using Shelvance.Core.Security;
using Shelvance.Test.Common;

namespace Shelvance.Core.Test.Framework
{
    public abstract class CoreTest : TestBase
    {
        protected void UseRealHttp()
        {
            Mocker.GetMock<IPlatformInfo>().SetupGet(c => c.Version).Returns(new Version("3.0.0"));
            Mocker.GetMock<IOsInfo>().SetupGet(c => c.Version).Returns("1.0.0");
            Mocker.GetMock<IOsInfo>().SetupGet(c => c.Name).Returns("TestOS");

            Mocker.SetConstant<IHttpProxySettingsProvider>(new HttpProxySettingsProvider(Mocker.Resolve<ConfigService>()));
            Mocker.SetConstant<ICreateManagedWebProxy>(new ManagedWebProxyFactory(Mocker.Resolve<CacheManager>()));
            Mocker.SetConstant<ICertificateValidationService>(new X509CertificateValidationService(Mocker.Resolve<ConfigService>(), TestLogger));
            Mocker.SetConstant<IHttpDispatcher>(new ManagedHttpDispatcher(Mocker.Resolve<IHttpProxySettingsProvider>(), Mocker.Resolve<ICreateManagedWebProxy>(), Mocker.Resolve<ICertificateValidationService>(), Mocker.Resolve<UserAgentBuilder>(), Mocker.Resolve<CacheManager>(), TestLogger));
            Mocker.SetConstant<IHttpClient>(new HttpClient(Array.Empty<IHttpRequestInterceptor>(), Mocker.Resolve<CacheManager>(), Mocker.Resolve<RateLimitService>(), Mocker.Resolve<IHttpDispatcher>(), TestLogger));
            Mocker.SetConstant<IShelvanceCloudRequestBuilder>(new ShelvanceCloudRequestBuilder());
            Mocker.SetConstant<IMetadataRequestBuilder>(Mocker.Resolve<MetadataRequestBuilder>());

            var httpClient = Mocker.Resolve<IHttpClient>();
            Mocker.GetMock<ICachedHttpResponseService>()
                .Setup(x => x.Get(It.IsAny<HttpRequest>(), It.IsAny<bool>(), It.IsAny<TimeSpan>()))
                .Returns((HttpRequest request, bool useCache, TimeSpan ttl) => httpClient.Get(request));
        }
    }

    public abstract class CoreTest<TSubject> : CoreTest
        where TSubject : class
    {
        private TSubject _subject;

        [SetUp]
        public void CoreTestSetup()
        {
            _subject = null;
        }

        protected TSubject Subject
        {
            get
            {
                if (_subject == null)
                {
                    _subject = Mocker.Resolve<TSubject>();
                }

                return _subject;
            }
        }
    }
}
