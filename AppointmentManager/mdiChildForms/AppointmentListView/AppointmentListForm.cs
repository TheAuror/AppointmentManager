using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppointmentManager.BusinessLayer.AppointmentModels;
using AppointmentManager.BusinessLayer.StudentModels;

namespace AppointmentManager.PresentationLayer.mdiChildForms.AppointmentListView
{
    public partial class AppointmentListForm : Form
    {
        private readonly AppointmentListViewModel _appointmentListViewModel;
        public AppointmentListForm(AppointmentListViewModel appointmentListViewModel)
        {
            _appointmentListViewModel = appointmentListViewModel;
            InitializeComponent();
        }

        private void AppointmentListForm_Load(object sender, EventArgs e)
        {
            _appointmentListViewModel.LoadAppointments();
            _appointmentListViewModel.LoadStudents();
            appointmentBindingSource.DataSource = _appointmentListViewModel.AllAppointments.OrderBy(a => a.Appointment).Select(a => a.Appointment > DateTime.Now);
            studentBindingSource.DataSource = _appointmentListViewModel.AllStudents;
            comboBox.SelectedItem = studentBindingSource.DataMember.First();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker.Value.Date;
            var date2 = date.AddHours((double) numericUpDown.Value);
            if (date2 > DateTime.Now && _appointmentListViewModel.AllAppointments.Any(d => d.Appointment.Equals(date2)))
            {
                return;
            }
            _appointmentListViewModel.Appointment = new AppointmentModel
            {
                StudentId     = (int) comboBox.SelectedValue,
                StudentName   = ((StudentModel) comboBox.SelectedItem).Name,
                StudentCourse = ((StudentModel) studentBindingSource.Current).Course,
                Appointment   = date2
            };
            _appointmentListViewModel.SaveAppointment();
            _appointmentListViewModel.LoadAppointments();
            appointmentBindingSource.DataSource = _appointmentListViewModel.AllAppointments.OrderBy(a => a.Appointment).Select(a => a.Appointment > DateTime.Now);
        }

        private void AppointmentListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
