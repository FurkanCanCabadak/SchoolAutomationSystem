using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Teacher:AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TeacherNumber { get; set; }//Bu numara ile giriş olacak.
        public string Password { get; set; }
        public string MyProperty { get; set; }
    }
}