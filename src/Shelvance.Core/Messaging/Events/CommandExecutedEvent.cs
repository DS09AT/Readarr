using Shelvance.Common.Messaging;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Messaging.Events
{
    public class CommandExecutedEvent : IEvent
    {
        public CommandModel Command { get; private set; }

        public CommandExecutedEvent(CommandModel command)
        {
            Command = command;
        }
    }
}
