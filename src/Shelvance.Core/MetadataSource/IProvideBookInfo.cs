using System;
using System.Collections.Generic;
using Shelvance.Core.Books;

namespace Shelvance.Core.MetadataSource
{
    public interface IProvideBookInfo
    {
        Tuple<string, Book, List<AuthorMetadata>> GetBookInfo(string id);
    }
}
