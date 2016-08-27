using Autofac;
using Autofac.Core;

namespace AppointmentManager.DataLayer.Common
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<IContext>()
                .WithParameter("connectionString", "AppointmentManager")
                .InstancePerLifetimeScope();
        }
    }
}
