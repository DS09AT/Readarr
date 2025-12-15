using System;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Update.History
{
    public class UpdateHistory : ModelBase
    {
        public DateTime Date { get; set; }
        public Version Version { get; set; }
        public UpdateHistoryEventType EventType { get; set; }
    }
}
