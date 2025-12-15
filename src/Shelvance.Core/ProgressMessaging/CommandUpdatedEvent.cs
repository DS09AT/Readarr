using Shelvance.Common.Messaging;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.ProgressMessaging
{
    public class CommandUpdatedEvent : IEvent
    {
        public CommandModel Command { get; set; }

        public CommandUpdatedEvent(CommandModel command)
        {
            Command = command;
        }
    }
}
