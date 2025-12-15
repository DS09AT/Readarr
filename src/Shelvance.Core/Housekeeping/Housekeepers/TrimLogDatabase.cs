using Shelvance.Core.Instrumentation;

namespace Shelvance.Core.Housekeeping.Housekeepers
{
    public class TrimLogDatabase : IHousekeepingTask
    {
        private readonly ILogRepository _logRepo;

        public TrimLogDatabase(ILogRepository logRepo)
        {
            _logRepo = logRepo;
        }

        public void Clean()
        {
            _logRepo.Trim();
        }
    }
}
