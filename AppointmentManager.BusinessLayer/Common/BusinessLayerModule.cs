using AppointmentManager.BusinessLayer.StudentModels;
using AppointmentManager.DataLayer;
using Autofac;

namespace AppointmentManager.BusinessLayer.Common
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().
                    As<IStudentService>().
                    InstancePerLifetimeScope();
            builder.RegisterAssemblyModules(
                typeof (ISampleContext).Assembly);
        }
    }
}
