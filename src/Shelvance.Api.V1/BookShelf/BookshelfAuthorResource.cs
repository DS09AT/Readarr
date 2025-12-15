using System.Collections.Generic;
using Shelvance.Api.V1.Books;

namespace Shelvance.Api.V1.Bookshelf
{
    public class BookshelfAuthorResource
    {
        public int Id { get; set; }
        public bool? Monitored { get; set; }
        public List<BookResource> Books { get; set; }
    }
}
