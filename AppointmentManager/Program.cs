using System;
using System.Windows.Forms;
using AppointmentManager.BusinessLayer.AppointmentModels;
using Autofac;
using AppointmentManager.BusinessLayer.StudentModels;
using AppointmentManager.PresentationLayer.mdiChildForms.AppointmentListView;
using AppointmentManager.PresentationLayer.mdiChildForms.StudentListView;
using Autofac.Core;

namespace AppointmentManager.PresentationLayer
{
    static class Program
    {
        public static IContainer Container;
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof (IStudentService).Assembly);
            builder.RegisterAssemblyModules(typeof (IAppointmentService).Assembly);
            builder.Register(context => new MainForm(context.Resolve<IStudentService>())).Named<Form>("MainForm").SingleInstance();
            builder.RegisterType<StudentListViewModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AppointmentListViewModel>().AsSelf().InstancePerLifetimeScope();
            builder.Register(context => new StudentListForm(context.Resolve<StudentListViewModel>())).Named<Form>("StudentListForm").SingleInstance();
            builder.Register(context => new AppointmentListForm(context.Resolve<AppointmentListViewModel>())).Named<Form>("AppointmentListForm").SingleInstance();
            builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();

            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.ResolveNamed<Form>("MainForm"));
        }
    }
}
