using System.Collections.Generic;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Books
{
    public class MonitoringOptions : IEmbeddedDocument
    {
        public MonitoringOptions()
        {
            BooksToMonitor = new List<string>();
        }

        public MonitorTypes Monitor { get; set; }
        public List<string> BooksToMonitor { get; set; }
        public bool Monitored { get; set; }
    }
}
