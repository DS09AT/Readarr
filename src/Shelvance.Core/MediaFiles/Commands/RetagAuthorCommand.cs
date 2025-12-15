using System.Collections.Generic;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.MediaFiles.Commands
{
    public class RetagAuthorCommand : Command
    {
        public List<int> AuthorIds { get; set; }
        public bool UpdateCovers { get; set; }
        public bool EmbedMetadata { get; set; }

        public override bool SendUpdatesToClient => true;
        public override bool RequiresDiskAccess => true;

        public RetagAuthorCommand()
        {
            AuthorIds = new List<int>();
        }
    }
}
