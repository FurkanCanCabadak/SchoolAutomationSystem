using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class StudentAffairRepository : IGenericRepository<StudentAffair>
    {
        DataAccess db = new DataAccess();
        public bool Add(StudentAffair entity)
        {
            bool result = false;
            try
            {
                var studentAffair = new StudentAffair();
                studentAffair.Name = entity.Name;
                studentAffair.Surname = entity.Surname;
                studentAffair.Email = entity.Email;
                studentAffair.Phone = entity.Phone;
                studentAffair.RoleId = entity.RoleId;




                db.StudentAffair.Add(studentAffair);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var studentAffair = db.StudentAffair.Find(id);
            if (studentAffair != null)
            {
                studentAffair.RoleId = 2;
                studentAffair.IsDelete = true;
                db.SaveChanges();
                result = true;

            }

            return result;
        }

        public StudentAffair Detail(int id)
        {
            var studentAffair = db.StudentAffair.Find(id);

            return studentAffair;
        }

        public bool Edit(StudentAffair entity)
        {

            bool result = false;
            try
            {

                StudentAffair studentAffair = db.StudentAffair.Find(entity.Id);
                studentAffair.Name = entity.Name;
                studentAffair.Surname = entity.Surname;
                studentAffair.Email = entity.Email;
                studentAffair.Phone = entity.Phone;
                studentAffair.Password= entity.Password;
                studentAffair.IsStatus= entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }
        public List<StudentAffair> List()
        {
            return db.StudentAffair.Where(x => x.IsDelete == false).ToList();
        }
    }

    

}

