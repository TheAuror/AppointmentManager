using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace AppointmentManager.BusinessLayer.StudentModels
{
    sealed class StudentModelClassMap : CsvClassMap<StudentModel>
    {
        public StudentModelClassMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Course).Index(1);
        }
    }
}
