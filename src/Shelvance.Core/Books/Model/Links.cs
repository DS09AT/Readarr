using Equ;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Books
{
    public class Links : MemberwiseEquatable<Links>, IEmbeddedDocument
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
