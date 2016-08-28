using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.BusinessLayer.Common;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.BusinessLayer.AppointmentModels
{
    public class AppointmentModel : BaseModel
    {
        private int _id;
        private int _studentId;
        private string _studentName;
        private string _studentCourse;
        private DateTime _appointment;

        public AppointmentModel() { }

        public AppointmentModel(AppointmentEntity appointmentEntity)
        {
            _id = appointmentEntity.Id;
            _studentId = appointmentEntity.StudentId;
            _studentName = appointmentEntity.StudentName;
            _studentCourse = appointmentEntity.StudentCourse;
            _appointment = appointmentEntity.Appointment;
        }

        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

        public int StudentId
        {
            get { return _studentId; }
            set { OnPropertyChanged(ref _studentId, value); }
        }

        public string StudentName
        {
            get { return _studentName; }
            set { OnPropertyChanged(ref _studentName, value); }
        }

        public string StudentCourse
        {
            get { return _studentCourse; }
            set { OnPropertyChanged(ref _studentCourse, value); }
        }

        public DateTime Appointment
        {
            get { return _appointment; }
            set { OnPropertyChanged(ref _appointment, value); }
        }
    }
}
