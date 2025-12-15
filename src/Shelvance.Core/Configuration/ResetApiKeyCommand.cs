using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Configuration
{
    public class ResetApiKeyCommand : Command
    {
        public override bool SendUpdatesToClient => true;
    }
}
