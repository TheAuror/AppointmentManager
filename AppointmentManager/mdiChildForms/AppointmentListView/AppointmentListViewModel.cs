using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.BusinessLayer.AppointmentModels;
using AppointmentManager.BusinessLayer.StudentModels;

namespace AppointmentManager.PresentationLayer.mdiChildForms.AppointmentListView
{
    public class AppointmentListViewModel
    {
        private readonly IStudentService _studentService;
        private readonly IAppointmentService _appointmentService;
        public BindingList<StudentModel> AllStudents;
        public BindingList<AppointmentModel> AllAppointments;
        public AppointmentModel Appointment;

        public AppointmentListViewModel(IStudentService studentService, IAppointmentService appointmentService)
        {
            _studentService = studentService;
            _appointmentService = appointmentService;
        }

        public void LoadStudents()
        {
            AllStudents = new BindingList<StudentModel>(_studentService.GetStudents());
        }

        public void LoadAppointments()
        {
            AllAppointments = new BindingList<AppointmentModel>(_appointmentService.GetAppointments());
        }

        public void SaveAppointment()
        {
            _appointmentService.SaveAppointment(Appointment);
            LoadAppointments();
        }
    }
}
