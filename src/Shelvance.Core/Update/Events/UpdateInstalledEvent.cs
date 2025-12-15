using System;
using Shelvance.Common.Messaging;

namespace Shelvance.Core.Update.History.Events
{
    public class UpdateInstalledEvent : IEvent
    {
        public Version PreviousVerison { get; set; }
        public Version NewVersion { get; set; }

        public UpdateInstalledEvent(Version previousVersion, Version newVersion)
        {
            PreviousVerison = previousVersion;
            NewVersion = newVersion;
        }
    }
}
