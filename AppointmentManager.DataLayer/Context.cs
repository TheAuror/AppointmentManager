using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.DataLayer
{
    public class Context : DbContext, IContext
    {
        public Context():this("AppointmentManager")
        {

        }
        public Context(string connectionString) 
            : base(connectionString)
        {

        }
        public IDbSet<StudentEntity> Students => Set<StudentEntity>();

        public IDbSet<AppointmentEntity> Appointments => Set<AppointmentEntity>();
    }
}
