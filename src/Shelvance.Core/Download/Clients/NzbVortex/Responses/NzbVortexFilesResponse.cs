using System.Collections.Generic;

namespace Shelvance.Core.Download.Clients.NzbVortex.Responses
{
    public class NzbVortexFilesResponse : NzbVortexResponseBase
    {
        public List<NzbVortexFile> Files { get; set; }
    }
}
