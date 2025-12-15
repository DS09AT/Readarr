using Shelvance.Common.Messaging;

namespace Shelvance.Core.HealthCheck
{
    public interface IProvideHealthCheck
    {
        HealthCheck Check();
        bool CheckOnStartup { get; }
        bool CheckOnSchedule { get; }
    }

    public interface IProvideHealthCheckWithMessage : IProvideHealthCheck
    {
        HealthCheck Check(IEvent message);
    }
}
