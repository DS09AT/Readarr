using Shelvance.Core.MediaFiles;

namespace Shelvance.Core.Notifications.Webhook
{
    public class WebhookRenamedBookFile : WebhookBookFile
    {
        public WebhookRenamedBookFile(RenamedBookFile renamedMovie)
            : base(renamedMovie.BookFile)
        {
            PreviousPath = renamedMovie.PreviousPath;
        }

        public string PreviousPath { get; set; }
    }
}
