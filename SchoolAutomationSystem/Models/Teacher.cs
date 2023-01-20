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
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public int TeacherNumber { get; set; }//Bu numara ile giriş olacak.
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}