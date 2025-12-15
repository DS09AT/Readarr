using System.Collections.Generic;
using Shelvance.Core.Books;

namespace Shelvance.Core.MetadataSource
{
    public interface ISearchForNewAuthor
    {
        List<Author> SearchForNewAuthor(string title);
    }
}
