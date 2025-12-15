using System.Text;
using NLog;
using NLog.Targets;

namespace Shelvance.Common.Instrumentation
{
    public class ShelvanceFileTarget : FileTarget
    {
        protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
        {
            var result = CleanseLogMessage.Cleanse(Layout.Render(logEvent));
            target.Append(result);
        }
    }
}
