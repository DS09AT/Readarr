using System.Collections.Generic;
using Shelvance.Core.Books;
using Shelvance.Core.CustomFormats;
using Shelvance.Core.Datastore;
using Shelvance.Core.DecisionEngine;
using Shelvance.Core.Parser.Model;
using Shelvance.Core.Qualities;

namespace Shelvance.Core.MediaFiles.BookImport.Manual
{
    public class ManualImportItem : ModelBase
    {
        public ManualImportItem()
        {
            CustomFormats = new List<CustomFormat>();
        }

        public string Path { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
        public Edition Edition { get; set; }
        public QualityModel Quality { get; set; }
        public string ReleaseGroup { get; set; }
        public string DownloadId { get; set; }
        public List<CustomFormat> CustomFormats { get; set; }
        public int IndexerFlags { get; set; }
        public IEnumerable<Rejection> Rejections { get; set; }
        public ParsedTrackInfo Tags { get; set; }
        public bool AdditionalFile { get; set; }
        public bool ReplaceExistingFiles { get; set; }
        public bool DisableReleaseSwitching { get; set; }
    }
}
