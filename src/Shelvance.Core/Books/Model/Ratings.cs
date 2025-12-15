using Equ;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Books
{
    public class Ratings : MemberwiseEquatable<Ratings>, IEmbeddedDocument
    {
        public int Votes { get; set; }
        public decimal Value { get; set; }

        public double Popularity => (double)Value * Votes;
    }
}
