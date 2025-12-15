using System;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Http
{
    public class CachedHttpResponse : ModelBase
    {
        public string Url { get; set; }
        public DateTime LastRefresh { get; set; }
        public DateTime Expiry { get; set; }
        public string Value { get; set; }
        public int StatusCode { get; set; }
    }
}
