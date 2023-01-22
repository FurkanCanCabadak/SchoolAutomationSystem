using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class TeacherRoleLesson
    {
        public Teacher SingleTeacher { get; set; }
        public List<Teacher> TeacherList { get; set; }
        public Role SingleRole { get; set; }
        public List<Role> RoleList { get; set; }
        public Lesson SingleLesson { get; set; }
        public List<Lesson> LessonList { get; set; }
    }
}