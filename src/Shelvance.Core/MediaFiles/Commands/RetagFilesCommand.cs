using System.Collections.Generic;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.MediaFiles.Commands
{
    public class RetagFilesCommand : Command
    {
        public int AuthorId { get; set; }
        public List<int> Files { get; set; }
        public bool UpdateCovers { get; set; }
        public bool EmbedMetadata { get; set; }

        public override bool SendUpdatesToClient => true;
        public override bool RequiresDiskAccess => true;

        public RetagFilesCommand()
        {
        }

        public RetagFilesCommand(int authorId, List<int> files)
        {
            AuthorId = authorId;
            Files = files;
        }
    }
}
