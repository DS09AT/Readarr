using Shelvance.Common.Messaging;

namespace Shelvance.Core.CustomFormats.Events
{
    public class CustomFormatDeletedEvent : IEvent
    {
        public CustomFormatDeletedEvent(CustomFormat format)
        {
            CustomFormat = format;
        }

        public CustomFormat CustomFormat { get; private set; }
    }
}
