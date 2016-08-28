using System;
using System.Windows.Forms;
using Autofac;
using AppointmentManager.BusinessLayer.StudentModels;
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

            builder.RegisterAssemblyModules(typeof(IStudentService).Assembly);
            builder.Register(context => new MainForm(context.Resolve<IStudentService>())).Named<Form>("MainForm").SingleInstance();
            builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();

            Container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.ResolveNamed<Form>("MainForm"));
        }
    }
}
