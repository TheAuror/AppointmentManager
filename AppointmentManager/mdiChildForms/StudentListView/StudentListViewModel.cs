using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentManager.BusinessLayer.StudentModels;

namespace AppointmentManager.PresentationLayer.mdiChildForms.StudentListView
{
    public class StudentListViewModel
    {
        private readonly IStudentService _studentService;
        public BindingList<StudentModel> AllStudents { get; private set; }

        public StudentListViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void LoadStudents()
        {
            var list = _studentService.GetStudents();
            AllStudents = new BindingList<StudentModel>(list);
        }
    }
}
