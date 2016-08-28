using System.ComponentModel;
using AppointmentManager.BusinessLayer.Common;
using AppointmentManager.DataLayer.Entities;

namespace AppointmentManager.BusinessLayer.StudentModels
{
    public class StudentModel : BaseModel
    {
        private int _id;
        private string _name;
        private string _course;

        public StudentModel(){}
        public StudentModel(StudentEntity studentEntity)
        {
            _id = studentEntity.Id;
            _name = studentEntity.Name;
            _course = studentEntity.Course;
        }

        public int Id
        {
            get { return _id; }
            set { OnPropertyChanged(ref _id, value); }
        }

        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        public string Course
        {
            get { return _course; }
            set { OnPropertyChanged(ref _course, value); }
        }
    }
}
