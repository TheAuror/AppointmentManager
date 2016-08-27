using System.Data.Entity;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.DataLayer
{
    public interface ISampleContext
    {
        IDbSet<StudentEntity> Students { get; }
        IDbSet<AppointmentEntity> Appointments { get; }

        int SaveChanges();
    }
}
