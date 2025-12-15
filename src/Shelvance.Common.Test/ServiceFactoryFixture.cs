using System.Linq;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Shelvance.Common.Composition.Extensions;
using Shelvance.Common.EnvironmentInfo;
using Shelvance.Common.Instrumentation.Extensions;
using Shelvance.Common.Options;
using Shelvance.Core.Datastore;
using Shelvance.Core.Datastore.Extensions;
using Shelvance.Core.Lifecycle;
using Shelvance.Core.Messaging.Events;
using Shelvance.Host;
using Shelvance.Test.Common;

namespace Shelvance.Common.Test
{
    [TestFixture]
    public class ServiceFactoryFixture : TestBase<ServiceFactory>
    {
        [Test]
        public void event_handlers_should_be_unique()
        {
            var container = new Container(rules => rules.WithShelvanceRules())
                .AddShelvanceLogger()
                .AutoAddServices(Bootstrap.ASSEMBLIES)
                .AddDummyDatabase()
                .AddStartupContext(new StartupContext("first", "second"));

            container.RegisterInstance(new Mock<IHostLifetime>().Object);
            container.RegisterInstance(new Mock<IOptions<PostgresOptions>>().Object);
            container.RegisterInstance(new Mock<IOptions<AppOptions>>().Object);
            container.RegisterInstance(new Mock<IOptions<AuthOptions>>().Object);
            container.RegisterInstance(new Mock<IOptions<ServerOptions>>().Object);
            container.RegisterInstance(new Mock<IOptions<LogOptions>>().Object);
            container.RegisterInstance(new Mock<IOptions<UpdateOptions>>().Object);

            var serviceProvider = container.GetServiceProvider();
            serviceProvider.GetRequiredService<IAppFolderFactory>().Register();

            Mocker.SetConstant<System.IServiceProvider>(serviceProvider);

            var handlers = Subject.BuildAll<IHandle<ApplicationStartedEvent>>()
                                  .Select(c => c.GetType().FullName);

            handlers.Should().OnlyHaveUniqueItems();
        }
    }
}
