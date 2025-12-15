using System.Xml.Linq;

namespace Shelvance.Core.MetadataSource.Goodreads
{
    public abstract class GoodreadsResource
    {
        public abstract string ElementName { get; }

        public abstract void Parse(XElement element);
    }
}
