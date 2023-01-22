using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class AdminRepository : IGenericRepository<Admin>
    {
        DataAccess db = new DataAccess();
        public bool Add(Admin entity)
        {
            bool result = false;
            try
            {
                var admin = new Admin();
                admin.Name = entity.Name;
                admin.Surname = entity.Surname;
                admin.Email = entity.Email;
                admin.Phone = entity.Phone;
                admin.UserName = entity.UserName;
                admin.Password = entity.Password;
                admin.RoleId = entity.RoleId;
                admin.IsStatus = entity.IsStatus;

                db.Admin.Add(admin);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var admin = db.Admin.Find(id);
            if (admin != null)
            {
                admin.IsDelete = true;
                db.SaveChanges();
                result = true;

            }

            return result;
        }

        public Admin Detail(int id)
        {
            var admin = db.Admin.Find(id);

            return admin;
        }

        public bool Edit(Admin entity)
        {
            bool result = false;
            try
            {

                Admin admin = db.Admin.Find(entity.Id);
                admin.Name = entity.Name;
                admin.Surname = entity.Surname;
                admin.Email = entity.Email;
                admin.Phone = entity.Phone;
                admin.UserName = entity.UserName;
                admin.Password = entity.Password;
                admin.RoleId = entity.RoleId;
                admin.IsStatus = entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Admin> List()
        {
            return db.Admin.Where(x => x.IsDelete == false).ToList();
        }
        public Admin AdminAccount(string userName)
        {
            var admin = db.Admin.FirstOrDefault(x => x.UserName == userName);

            return admin;
        }
    }
}