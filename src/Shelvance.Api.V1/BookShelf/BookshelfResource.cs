using System.Collections.Generic;
using Shelvance.Core.Books;

namespace Shelvance.Api.V1.Bookshelf
{
    public class BookshelfResource
    {
        public List<BookshelfAuthorResource> Authors { get; set; }
        public MonitoringOptions MonitoringOptions { get; set; }
        public NewItemMonitorTypes? MonitorNewItems { get; set; }
    }
}
