using Shelvance.Core.Datastore;
using Shelvance.Core.Instrumentation.Commands;
using Shelvance.Core.Messaging.Commands;

namespace Shelvance.Core.Instrumentation
{
    public interface ILogService
    {
        PagingSpec<Log> Paged(PagingSpec<Log> pagingSpec);
    }

    public class LogService : ILogService, IExecute<ClearLogCommand>
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public PagingSpec<Log> Paged(PagingSpec<Log> pagingSpec)
        {
            return _logRepository.GetPaged(pagingSpec);
        }

        public void Execute(ClearLogCommand message)
        {
            _logRepository.Purge(vacuum: true);
        }
    }
}
