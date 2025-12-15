using System.Linq;
using NLog;
using Shelvance.Core.DecisionEngine;
using Shelvance.Core.Download;
using Shelvance.Core.Parser.Model;

namespace Shelvance.Core.MediaFiles.BookImport.Specifications
{
    public class SameFileSpecification : IImportDecisionEngineSpecification<LocalBook>
    {
        private readonly Logger _logger;

        public SameFileSpecification(Logger logger)
        {
            _logger = logger;
        }

        public Decision IsSatisfiedBy(LocalBook localBook, DownloadClientItem downloadClientItem)
        {
            var bookFiles = localBook.Book?.BookFiles?.Value;

            if (bookFiles == null || !bookFiles.Any())
            {
                _logger.Debug("No existing book file, skipping");
                return Decision.Accept();
            }

            foreach (var bookFile in bookFiles)
            {
                if (bookFile == null)
                {
                    var book = localBook.Book;
                    _logger.Trace("Unable to get book file details from the DB. BookId: {0}", book.Id);

                    return Decision.Accept();
                }

                if (bookFile.Size == localBook.Size)
                {
                    _logger.Debug("'{0}' Has the same filesize as existing file", localBook.Path);
                    return Decision.Reject("Has the same filesize as existing file");
                }
            }

            return Decision.Accept();
        }
    }
}
