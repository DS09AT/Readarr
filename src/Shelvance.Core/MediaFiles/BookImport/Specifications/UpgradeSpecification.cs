using System.Linq;
using NLog;
using Shelvance.Core.Configuration;
using Shelvance.Core.CustomFormats;
using Shelvance.Core.DecisionEngine;
using Shelvance.Core.Download;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Qualities;

namespace Shelvance.Core.MediaFiles.BookImport.Specifications
{
    public class UpgradeSpecification : IImportDecisionEngineSpecification<LocalBook>
    {
        private readonly IConfigService _configService;
        private readonly ICustomFormatCalculationService _customFormatCalculationService;
        private readonly Logger _logger;

        public UpgradeSpecification(IConfigService configService,
                                    ICustomFormatCalculationService customFormatCalculationService,
                                    Logger logger)
        {
            _configService = configService;
            _customFormatCalculationService = customFormatCalculationService;
            _logger = logger;
        }

        public Decision IsSatisfiedBy(LocalBook item, DownloadClientItem downloadClientItem)
        {
            var files = item.Book?.BookFiles?.Value;
            if (files == null || !files.Any())
            {
                // No existing books, skip.  This guards against new authors not having a QualityProfile.
                return Decision.Accept();
            }

            var downloadPropersAndRepacks = _configService.DownloadPropersAndRepacks;
            var qualityComparer = new QualityModelComparer(item.Author.QualityProfile);

            foreach (var bookFile in files)
            {
                var qualityCompare = qualityComparer.Compare(item.Quality.Quality, bookFile.Quality.Quality);

                if (qualityCompare < 0)
                {
                    _logger.Debug("This file isn't a quality upgrade for all books. Skipping {0}", item.Path);
                    return Decision.Reject("Not an upgrade for existing book file(s)");
                }

                if (qualityCompare == 0 && downloadPropersAndRepacks != ProperDownloadTypes.DoNotPrefer &&
                    item.Quality.Revision.CompareTo(bookFile.Quality.Revision) < 0)
                {
                    _logger.Debug("This file isn't a quality upgrade for all books. Skipping {0}", item.Path);
                    return Decision.Reject("Not an upgrade for existing book file(s)");
                }
            }

            return Decision.Accept();
        }
    }
}
