using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class StudentDepartment
    {
        public Student SingleStudent { get; set; }
        public List<Student> StudentList { get; set; }
        public Department SingleDepartment { get; set; }
        public List<Department> DepartmentList { get; set; }
    }
}