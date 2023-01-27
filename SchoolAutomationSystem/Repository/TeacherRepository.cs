using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class TeacherRepository : IGenericRepository<Teacher>
    {
        DataAccess db = new DataAccess();
        public bool Add(Teacher entity)
        {

            bool result = false;
            try
            {
                var teacher = new Teacher();
                teacher.Name = entity.Name;
                teacher.Surname = entity.Surname;
                teacher.UserName = entity.UserName;
                teacher.Password = entity.Password;
                teacher.Email = entity.Email;
                teacher.Phone = entity.Phone;
                teacher.Title = entity.Title;
                teacher.LessonId = entity.LessonId;
                teacher.RoleId = entity.RoleId;
              



                db.Teacher.Add(teacher);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var teacher = db.Teacher.Find(id);
            if (teacher != null)
            {
                teacher.IsDelete = true;
                db.SaveChanges();
                result = true;

            }

            return result;
        }

        public Teacher Detail(int id)
        {
            var teacher = db.Teacher.Find(id);

            return teacher;
        }

        public bool Edit(Teacher entity)
        {
            bool result = false;
            try
            {

                Teacher teacher = db.Teacher.Find(entity.Id);
                teacher.Name = entity.Name;
                teacher.Surname = entity.Surname;
                teacher.UserName = entity.UserName;
                teacher.Password = entity.Password;
                teacher.Email = entity.Email;
                teacher.Phone = entity.Phone;
                teacher.Title = entity.Title;
                teacher.LessonId = entity.LessonId;
                teacher.RoleId = entity.RoleId;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Teacher> List()
        {
            return db.Teacher.Where(x => x.IsDelete == false).ToList();
        }
    }
}