using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class RoleRepository : IGenericRepository<Role>
    {
        DataAccess db = new DataAccess();

        public bool Add(Role entity)
        {
            bool result = false;
            try
            {
                var role = new Role();

                role.Name = entity.Name;

                db.Role.Add(role);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var role = db.Role.Find(id);
            if (role != null)
            {
                role.IsDelete = true;
                db.SaveChanges();
                result = true;

            }
            return result;
        }

        public Role Detail(int id)
        {
            var role = db.Role.Find(id);

            return role;
        }

        public bool Edit(Role entity)
        {
            bool result = false;
            try
            {

                Role role = db.Role.Find(entity.Id);
                role.Name = entity.Name;
                role.IsStatus = entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Role> List()
        {
            return db.Role.Where(x => x.IsDelete == false).ToList();
        }
    }
}