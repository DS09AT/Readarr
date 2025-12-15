using System.Collections.Generic;
using Shelvance.Core.Books;

namespace Shelvance.Core.MetadataSource
{
    public interface ISearchForNewBook
    {
        List<Book> SearchForNewBook(string title, string author, bool getAllEditions = true);
        List<Book> SearchByIsbn(string isbn);
        List<Book> SearchByAsin(string asin);
        List<Book> SearchByGoodreadsBookId(int goodreadsId, bool getAllEditions);
    }
}
