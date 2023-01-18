using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Department:AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinGraduateCredit { get; set; }//Mezun olmak için gerekli minimum ders kredisi.
        public List<Student> Student { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}