using Newtonsoft.Json.Linq;

namespace Shelvance.Common.Http
{
    public class JsonRpcResponse<T>
    {
        public string Id { get; set; }
        public T Result { get; set; }
        public JToken Error { get; set; }
    }
}
