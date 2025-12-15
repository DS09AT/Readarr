using Newtonsoft.Json;
using Shelvance.Core.Download.Clients.NzbVortex.JsonConverters;

namespace Shelvance.Core.Download.Clients.NzbVortex.Responses
{
    public class NzbVortexResponseBase
    {
        [JsonConverter(typeof(NzbVortexResultTypeConverter))]
        public NzbVortexResultType Result { get; set; }
    }
}
