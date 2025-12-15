using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Indexers.Gutenberg.Commands
{
    public class GutenbergCatalogUpdateCommand : Command
    {
        public override bool SendUpdatesToClient => true;
        public override bool IsLongRunning => true;

        public override string CompletionMessage => "Project Gutenberg catalog update completed";
    }
}
