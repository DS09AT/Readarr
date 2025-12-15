using Shelvance.Core.CustomFormats;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Profiles
{
    public class ProfileFormatItem : IEmbeddedDocument
    {
        public CustomFormat Format { get; set; }
        public int Score { get; set; }
    }
}
