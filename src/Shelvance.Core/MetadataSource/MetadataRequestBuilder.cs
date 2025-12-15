using Shelvance.Common.Cloud;
using Shelvance.Common.Extensions;
using Shelvance.Common.Http;
using Shelvance.Core.Configuration;

namespace Shelvance.Core.MetadataSource
{
    public interface IMetadataRequestBuilder
    {
        IHttpRequestBuilderFactory GetRequestBuilder();
    }

    public class MetadataRequestBuilder : IMetadataRequestBuilder
    {
        private readonly IConfigService _configService;

        private readonly IShelvanceCloudRequestBuilder _defaultRequestFactory;

        public MetadataRequestBuilder(IConfigService configService, IShelvanceCloudRequestBuilder defaultRequestBuilder)
        {
            _configService = configService;
            _defaultRequestFactory = defaultRequestBuilder;
        }

        public IHttpRequestBuilderFactory GetRequestBuilder()
        {
            if (_configService.MetadataSource.IsNotNullOrWhiteSpace())
            {
                return new HttpRequestBuilder(_configService.MetadataSource.TrimEnd("/") + "/{route}").KeepAlive().CreateFactory();
            }
            else
            {
                return _defaultRequestFactory.Metadata;
            }
        }
    }
}
