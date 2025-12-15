using System.Threading.Tasks;
using NLog;
using Shelvance.Common.Disk;
using Shelvance.Common.Http;
using Shelvance.Core.Configuration;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.RemotePathMappings;
using Shelvance.Core.ThingiProvider;

namespace Shelvance.Core.Download
{
    public abstract class HttpClientBase<TSettings> : DownloadClientBase<TSettings>
        where TSettings : IProviderConfig, new()
    {
        protected readonly IHttpClient _httpClient;

        protected HttpClientBase(IHttpClient httpClient,
                                IConfigService configService,
                                IDiskProvider diskProvider,
                                IRemotePathMappingService remotePathMappingService,
                                Logger logger)
            : base(configService, diskProvider, remotePathMappingService, logger)
        {
            _httpClient = httpClient;
        }

        public override DownloadProtocol Protocol => DownloadProtocol.Http;

        protected abstract string AddFromHttpUrl(RemoteBook remoteBook, string url);

        public override Task<string> Download(RemoteBook remoteBook, IIndexer indexer)
        {
            var url = remoteBook.Release.DownloadUrl;

            _logger.Info("Adding HTTP download [{0}] to the queue.", remoteBook.Release.Title);
            var downloadId = AddFromHttpUrl(remoteBook, url);

            return Task.FromResult(downloadId);
        }
    }
}
