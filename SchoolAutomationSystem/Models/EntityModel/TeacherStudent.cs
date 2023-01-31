using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class TeacherStudent
    {
        public Teacher SingleTeacher { get; set; }
        public List<Student> StudentList { get; set; }
    }
}