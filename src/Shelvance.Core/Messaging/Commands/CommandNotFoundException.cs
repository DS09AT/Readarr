using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Messaging.Commands
{
    public class CommandNotFoundException : ShelvanceException
    {
        public CommandNotFoundException(string contract)
            : base("Couldn't find command " + contract)
        {
        }
    }
}
