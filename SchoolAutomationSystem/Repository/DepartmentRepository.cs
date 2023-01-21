using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class DepartmentRepository : IGenericRepository<Department>
    {
        DataAccess db = new DataAccess();

        public bool Add(Department entity)
        {
            bool result = false;
            try
            {
                var department = new Department();
                department.Name = entity.Name;
                department.MinGraduateCredit = entity.MinGraduateCredit;
                department.Pay = entity.Pay;
                department.FacultyId = entity.FacultyId;

                db.Department.Add(department);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var department = db.Department.Find(id);
            if (department != null)
            {
                department.IsDelete = true;
                db.SaveChanges();
                result = true;

            }
            return result;
        }

        public Department Detail(int id)
        {
            var department = db.Department.Find(id);

            return department;
        }

        public bool Edit(Department entity)
        {
            bool result = false;
            try
            {

                Department department = db.Department.Find(entity.Id);
                department.Name = entity.Name;
                department.MinGraduateCredit = entity.MinGraduateCredit;
                department.Pay = entity.Pay;
                department.FacultyId = entity.FacultyId;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Department> List()
        {
            return db.Department.Where(x => x.IsDelete == false).ToList();
        }
    }
}