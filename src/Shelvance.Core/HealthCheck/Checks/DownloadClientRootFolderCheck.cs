using System;
using System.Linq;
using System.Net.Http;
using NLog;
using Shelvance.Common.Extensions;
using Shelvance.Core.Datastore.Events;
using Shelvance.Core.Download;
using Shelvance.Core.Download.Clients;
using Shelvance.Core.Localization;
using Shelvance.Core.RemotePathMappings;
using Shelvance.Core.RootFolders;
using Shelvance.Core.ThingiProvider.Events;

namespace Shelvance.Core.HealthCheck.Checks
{
    [CheckOn(typeof(ProviderAddedEvent<IDownloadClient>))]
    [CheckOn(typeof(ProviderUpdatedEvent<IDownloadClient>))]
    [CheckOn(typeof(ProviderDeletedEvent<IDownloadClient>))]
    [CheckOn(typeof(ModelEvent<RootFolder>))]
    [CheckOn(typeof(ModelEvent<RemotePathMapping>))]

    public class DownloadClientRootFolderCheck : HealthCheckBase, IProvideHealthCheck
    {
        private readonly IProvideDownloadClient _downloadClientProvider;
        private readonly IRootFolderService _rootFolderService;
        private readonly Logger _logger;

        public DownloadClientRootFolderCheck(IProvideDownloadClient downloadClientProvider,
                                      IRootFolderService rootFolderService,
                                      Logger logger,
                                      ILocalizationService localizationService)
            : base(localizationService)
        {
            _downloadClientProvider = downloadClientProvider;
            _rootFolderService = rootFolderService;
            _logger = logger;
        }

        public override HealthCheck Check()
        {
            // Only check clients not in failure status, those get another message
            var clients = _downloadClientProvider.GetDownloadClients(true);

            var rootFolders = _rootFolderService.All();

            foreach (var client in clients)
            {
                try
                {
                    var status = client.GetStatus();
                    var folders = status.OutputRootFolders;
                    foreach (var folder in folders)
                    {
                        if (rootFolders.Any(r => r.Path.PathEquals(folder.FullPath)))
                        {
                            return new HealthCheck(GetType(), HealthCheckResult.Warning, string.Format(_localizationService.GetLocalizedString("DownloadClientCheckDownloadingToRoot"), client.Definition.Name, folder.FullPath), "#downloads-in-root-folder");
                        }
                    }
                }
                catch (DownloadClientException ex)
                {
                    _logger.Debug(ex, "Unable to communicate with {0}", client.Definition.Name);
                }
                catch (HttpRequestException ex)
                {
                    _logger.Debug(ex, "Unable to communicate with {0}", client.Definition.Name);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Unknown error occured in DownloadClientRootFolderCheck HealthCheck");
                }
            }

            return new HealthCheck(GetType());
        }
    }
}
