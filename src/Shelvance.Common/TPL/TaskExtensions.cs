using System.Threading.Tasks;
using NLog;
using Shelvance.Common.Instrumentation;

namespace Shelvance.Common.TPL
{
    public static class TaskExtensions
    {
        private static readonly Logger Logger = ShelvanceLogger.GetLogger(typeof(TaskExtensions));

        public static Task LogExceptions(this Task task)
        {
            task.ContinueWith(t =>
                {
                    if (t.Exception != null)
                    {
                        var aggregateException = t.Exception.Flatten();
                        foreach (var exception in aggregateException.InnerExceptions)
                        {
                            Logger.Error(exception, "Task Error");
                        }
                    }
                }, TaskContinuationOptions.OnlyOnFaulted);

            return task;
        }
    }
}
