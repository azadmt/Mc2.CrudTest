using Autofac;
using Framework.Bus.MassTransit;
using Framework.Core.Bus;
using Framework.Core.Persistence;
using Framework.EventStore.Sql;

namespace Framework.Configuration.Autofac
{
    public class DependencyConfigurator
    {
        public static void Config(ContainerBuilder cb)
        {
            cb.RegisterType<BusControl>().As<ICommandBus>();
            cb.RegisterType<MassTransitBus>().As<IEventBus>();
            cb.RegisterType<AutofacContainer>().As<Core.IOC.IContainer>();
            cb.RegisterType<SqlServerEventStore>().As<IEventStore>();

        }

    }
}
