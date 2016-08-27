using AppointmentManager.DataLayer;
using Autofac;

namespace AppointmentManager.BusinessLayer.Common
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyModules(
                typeof (ISampleContext).Assembly);
        }
    }
}
