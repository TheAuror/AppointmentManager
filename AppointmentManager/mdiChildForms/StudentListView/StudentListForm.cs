using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppointmentManager.PresentationLayer.mdiChildForms.StudentListView
{
    public partial class StudentListForm : Form
    {
        private readonly StudentListViewModel _studentListViewModel;
        public StudentListForm(StudentListViewModel studentListViewModel)
        {
            _studentListViewModel = studentListViewModel;
            InitializeComponent();
            dataGridView.AutoGenerateColumns = true;
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            _studentListViewModel.LoadStudents();
            bindingSource.DataSource = _studentListViewModel.AllStudents;
        }
    }
}
