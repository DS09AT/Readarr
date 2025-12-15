using System.Collections.Generic;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.MediaFiles.BookImport.Manual
{
    public class ManualImportCommand : Command
    {
        public List<ManualImportFile> Files { get; set; }

        public override bool SendUpdatesToClient => true;
        public override bool RequiresDiskAccess => true;

        public ImportMode ImportMode { get; set; }
        public bool ReplaceExistingFiles { get; set; }
    }
}
