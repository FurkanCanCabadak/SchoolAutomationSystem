using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class FacultyRepository : IGenericRepository<Faculty>
    {
        DataAccess db = new DataAccess();

        public bool Add(Faculty entity)
        {
            bool result = false;
            try
            {
                var faculty = new Faculty();
                faculty.Name = entity.Name;
                faculty.SelectionStart = entity.SelectionStart;
                faculty.SelectionEnd = entity.SelectionEnd;
                faculty.IsStatus = entity.IsStatus;
                db.Faculty.Add(faculty);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var faculty = db.Faculty.Find(id);
            if (faculty != null)
            {
                faculty.IsDelete = true;
                db.SaveChanges();
                result = true;

            }
            return result;
        }

        public Faculty Detail(int id)
        {
            var faculty = db.Faculty.Find(id);

            return faculty;
        }

        public bool Edit(Faculty entity)
        {
            bool result = false;
            try
            {

                Faculty faculty = db.Faculty.Find(entity.Id);
                faculty.Name = entity.Name;
                faculty.SelectionStart = entity.SelectionStart;
                faculty.SelectionEnd = entity.SelectionEnd;
                faculty.IsStatus= entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Faculty> List()
        {
            return db.Faculty.Where(x => x.IsDelete == false).ToList();
        }
    }
}