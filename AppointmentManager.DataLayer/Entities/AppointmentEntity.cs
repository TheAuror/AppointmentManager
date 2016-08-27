using System;

namespace AppointmentManager.DataLayer.Entities
{
    public class AppointmentEntity
    {
        public virtual int Id { get; set; }
        public virtual int StudentId { get; set; }
        public virtual string StudentName { get; set; }
        public virtual string StudentCourse { get; set; }
        public virtual DateTime Appointment { get; set; }
    }
}
