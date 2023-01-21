using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class LessonRepository : IGenericRepository<Lesson>
    {
        DataAccess db = new DataAccess();

        public bool Add(Lesson entity)
        {
            bool result = false;
            try
            {
                var lesson = new Lesson();

                lesson.Name = entity.Name;
                lesson.Credit = entity.Credit;
                lesson.SelectionalTerm = entity.SelectionalTerm;
                lesson.DepartmentId = entity.DepartmentId;

                db.Lesson.Add(lesson);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var lesson = db.Lesson.Find(id);
            if (lesson != null)
            {
                lesson.IsDelete = true;
                db.SaveChanges();
                result = true;

            }
            return result;
        }

        public Lesson Detail(int id)
        {
            var lesson = db.Lesson.Find(id);

            return lesson;
        }

        public bool Edit(Lesson entity)
        {
            bool result = false;
            try
            {

                Lesson lesson = db.Lesson.Find(entity.Id);
                lesson.Name = entity.Name;
                lesson.Credit = entity.Credit;
                lesson.SelectionalTerm = entity.SelectionalTerm;
                lesson.DepartmentId = entity.DepartmentId;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Lesson> List()
        {
            return db.Lesson.Where(x => x.IsDelete == false).ToList();
        }
    }
}