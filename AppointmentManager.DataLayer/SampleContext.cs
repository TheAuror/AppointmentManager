using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.DataLayer
{
    public class SampleContext : DbContext, ISampleContext
    {
        public SampleContext():this("AppointmentManager")
        {

        }
        public SampleContext(string connectionString) 
            : base(connectionString)
        {

        }
        public IDbSet<StudentEntity> Students => Set<StudentEntity>();

        public IDbSet<AppointmentEntity> Appointments => Set<AppointmentEntity>();
    }
}
