using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class DepartmentFaculty
    {
        public Department SingleDepartment { get; set; }
        public List<Department> DepartmentList { get; set; }
        public Faculty SingleFaculty { get; set; }
        public List<Faculty> FacultyList { get; set; }
    }
}