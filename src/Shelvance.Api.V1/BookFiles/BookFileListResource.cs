using System.Collections.Generic;
using Shelvance.Core.Qualities;

namespace Shelvance.Api.V1.BookFiles
{
    public class BookFileListResource
    {
        public List<int> BookFileIds { get; set; }
        public QualityModel Quality { get; set; }
    }
}
