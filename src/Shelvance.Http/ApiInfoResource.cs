using System.Collections.Generic;

namespace Shelvance.Http
{
    public class ApiInfoResource
    {
        public string Current { get; set; }
        public List<string> Deprecated { get; set; }
    }
}
