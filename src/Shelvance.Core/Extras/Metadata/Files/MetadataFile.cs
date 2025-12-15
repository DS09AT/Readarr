using Shelvance.Core.Extras.Files;

namespace Shelvance.Core.Extras.Metadata.Files
{
    public class MetadataFile : ExtraFile
    {
        public string Hash { get; set; }
        public string Consumer { get; set; }
        public MetadataType Type { get; set; }
    }
}
