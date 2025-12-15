using System;
using System.Collections.Generic;
using Shelvance.Core.Books;

namespace Shelvance.Core.MetadataSource
{
    public interface IProvideAuthorInfo
    {
        Author GetAuthorInfo(string shelvanceId, bool useCache = true);
        HashSet<string> GetChangedAuthors(DateTime startTime);
    }
}
