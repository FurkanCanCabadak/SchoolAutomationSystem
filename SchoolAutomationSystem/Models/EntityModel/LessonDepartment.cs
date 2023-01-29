using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class LessonDepartment
    {
        public Department SingleDepartment { get; set; }
        public List<Department> DepartmentList { get; set; }
        public Lesson SingleLesson { get; set; }
        public List<Lesson> LessonList { get; set; }
    }
}