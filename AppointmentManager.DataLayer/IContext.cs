using System.Data.Entity;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.DataLayer
{
    public interface IContext
    {
        IDbSet<StudentEntity> Students { get; }
        IDbSet<AppointmentEntity> Appointments { get; }

        int SaveChanges();
    }
}
