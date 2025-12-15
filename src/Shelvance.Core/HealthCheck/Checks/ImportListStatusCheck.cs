using System.Linq;
using Shelvance.Common.Extensions;
using Shelvance.Core.ImportLists;
using Shelvance.Core.Localization;
using Shelvance.Core.ThingiProvider.Events;

namespace Shelvance.Core.HealthCheck.Checks
{
    [CheckOn(typeof(ProviderUpdatedEvent<IImportList>))]
    [CheckOn(typeof(ProviderDeletedEvent<IImportList>))]
    [CheckOn(typeof(ProviderStatusChangedEvent<IImportList>))]
    public class ImportListStatusCheck : HealthCheckBase
    {
        private readonly IImportListFactory _providerFactory;
        private readonly IImportListStatusService _providerStatusService;

        public ImportListStatusCheck(IImportListFactory providerFactory, IImportListStatusService providerStatusService, ILocalizationService localizationService)
            : base(localizationService)
        {
            _providerFactory = providerFactory;
            _providerStatusService = providerStatusService;
        }

        public override HealthCheck Check()
        {
            var enabledProviders = _providerFactory.GetAvailableProviders();
            var backOffProviders = enabledProviders.Join(_providerStatusService.GetBlockedProviders(),
                    i => i.Definition.Id,
                    s => s.ProviderId,
                    (i, s) => new { ImportList = i, Status = s })
                .ToList();

            if (backOffProviders.Empty())
            {
                return new HealthCheck(GetType());
            }

            if (backOffProviders.Count == enabledProviders.Count)
            {
                return new HealthCheck(GetType(), HealthCheckResult.Error, _localizationService.GetLocalizedString("ImportListStatusCheckAllClientMessage"), "#import-lists-are-unavailable-due-to-failures");
            }

            return new HealthCheck(GetType(), HealthCheckResult.Warning, string.Format(_localizationService.GetLocalizedString("ImportListStatusCheckSingleClientMessage"), string.Join(", ", backOffProviders.Select(v => v.ImportList.Definition.Name))), "#import-lists-are-unavailable-due-to-failures");
        }
    }
}
