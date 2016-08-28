using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppointmentManager.DataLayer;
using AppointmentManager.DataLayer.Entities;
using CsvHelper;

namespace AppointmentManager.BusinessLayer.StudentModels
{
    public class StudentService : IStudentService
    {
        private readonly ISampleContext _sampleContext;

        public StudentService(ISampleContext sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public List<StudentModel> GetStudents()
        {
            return _sampleContext.Students.Select(e => new StudentModel(e)).ToList();
        }

        public void SaveStudent(StudentModel student)
        {
            StudentEntity studentEntity;

            if (student.Id > 0)
            {
                studentEntity = _sampleContext.Students.FirstOrDefault(e => e.Id == student.Id);
            }
            else
            {
                studentEntity = new StudentEntity();
                _sampleContext.Students.Add(studentEntity);
            }
            if (studentEntity != null)
            {
                studentEntity.Name = student.Name;
                studentEntity.Course = student.Course;
            }
            _sampleContext.SaveChanges();
        }

        public void SaveStudents(List<StudentModel> studentsList)
        {
            foreach (StudentModel student in studentsList)
            {
                SaveStudent(student);
            }
        }

        public async void LoadAndSaveStudentsFromFileAsync(string filePath)
        {
            List<StudentModel> students = null;
            await Task.Run(() =>
            {
                using (StreamReader reader = (new StreamReader(filePath, Encoding.GetEncoding("iso-8859-2"))))
                {
                    var csv = new CsvReader(reader);
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.RegisterClassMap<StudentModelClassMap>();
                    students = new List<StudentModel>(csv.GetRecords<StudentModel>().ToList());
                }
            });
            if (students != null) SaveStudents(students);
        }
    }
}
