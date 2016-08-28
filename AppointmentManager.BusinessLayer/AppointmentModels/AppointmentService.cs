using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.DataLayer;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.BusinessLayer.AppointmentModels
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ISampleContext _sampleContext;

        public AppointmentService(ISampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public List<AppointmentModel> GetAppointments()
        {
            return _sampleContext.Appointments.Select(e => new AppointmentModel(e)).ToList();
        }

        public void SaveAppointment(AppointmentModel appointment)
        {
            AppointmentEntity appointmentEntity;
            if (appointment.Id > 0)
            {
                appointmentEntity = _sampleContext.Appointments.FirstOrDefault(e=>e.Id == appointment.Id);
            }
            else
            {
                appointmentEntity = new AppointmentEntity();
                _sampleContext.Appointments.Add(appointmentEntity);
            }
            if (appointmentEntity != null)
            {
                appointmentEntity.StudentId = appointment.StudentId;
                appointmentEntity.StudentName = appointment.StudentName;
                appointmentEntity.StudentCourse = appointment.StudentCourse;
                appointmentEntity.Appointment = appointment.Appointment;
            }
            _sampleContext.SaveChanges();
        }

        public void SaveAppointments(List<AppointmentModel> appointmentsList)
        {
            foreach (AppointmentModel appointment in appointmentsList)
            {
                SaveAppointment(appointment);
            }
        }
    }
}
