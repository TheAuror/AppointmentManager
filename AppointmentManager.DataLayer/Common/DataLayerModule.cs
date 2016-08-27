using Autofac;

namespace AppointmentManager.DataLayer.Common
{
    public class DataLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleContext>()
                .As<ISampleContext>()
                .WithParameter("connectionString", "AppointmentManager")
                .InstancePerLifetimeScope();
        }
    }
}
