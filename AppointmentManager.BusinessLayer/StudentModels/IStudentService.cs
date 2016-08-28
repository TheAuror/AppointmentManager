using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManager.BusinessLayer.StudentModels
{
    public interface IStudentService
    {
        List<StudentModel> GetStudents();
        void LoadAndSaveStudentsFromFileAsync(string filePath);
        void SaveStudent(StudentModel student);
        void SaveStudents(List<StudentModel> studentsList);
    }
}
