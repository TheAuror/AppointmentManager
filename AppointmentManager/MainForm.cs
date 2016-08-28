using System.Windows.Forms;
using AppointmentManager.BusinessLayer.StudentModels;
using AppointmentManager.PresentationLayer.Properties;
using Autofac;

namespace AppointmentManager.PresentationLayer
{
    public partial class MainForm : Form
    {
        private readonly IStudentService _studentService;
        public MainForm(IStudentService studentService)
        {
            _studentService = studentService;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            using (var lifetimeScope = Program.Container.BeginLifetimeScope())
            {
                var form = lifetimeScope.Resolve<LoginForm>();
                form.ShowDialog();
                if (form.DialogResult != DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void hallgatókBeolvasásaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.CheckFileExists = true;
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = Resources.MainForm_OpenFileDialog_CsvFilter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _studentService.LoadAndSaveStudentsFromFileAsync(openFileDialog.FileName);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
