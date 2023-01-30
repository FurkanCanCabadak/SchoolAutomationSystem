using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class StudentRepository : IGenericRepository<Student>
    {
        DataAccess db = new DataAccess();
        public bool Add(Student entity)
        {
            bool result = false;
            try
            {
                var student = new Student();
                student.Name = entity.Name;
                student.Surname = entity.Surname;
                student.UserName = entity.UserName;
                student.TCNumber = entity.TCNumber;
                student.Password = entity.Password;
                student.Email = entity.Email;
                student.Phone = entity.Phone;
                student.AdvisorId = entity.AdvisorId;
                student.Term = entity.Term;
                student.Scholarship = entity.Scholarship;
                student.TotalCredit = entity.TotalCredit;
                student.IsPayment = entity.IsPayment;
                student.IsGraduate = entity.IsGraduate;
                student.RoleId = entity.RoleId;
                student.DepartmentId = entity.DepartmentId;
                student.IsStatus= entity.IsStatus;
                student.IsDelete = false;


                db.Student.Add(student);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var student = db.Student.Find(id);
            if (student != null)
            {
                student.IsDelete = true;
                db.SaveChanges();
                result = true;

            }

            return result;
        }

        public Student Detail(int id)
        {
            var student = db.Student.Find(id);

            return student;
        }
        public Student DetailwithName(string userName)
        {
            var student = db.Student.FirstOrDefault(x=>x.UserName==userName);

            return student;
        }
        public bool Edit(Student entity)
        {

            bool result = false;
            try
            {

                Student student = db.Student.Find(entity.Id);
                student.Name = entity.Name;
                student.Surname = entity.Surname;
                student.UserName = entity.UserName;
                student.TCNumber = entity.TCNumber;
                student.Password = entity.Password;
                student.Email = entity.Email;
                student.Phone = entity.Phone;
                student.AdvisorId = entity.AdvisorId;
                student.Term = entity.Term;
                student.Scholarship = entity.Scholarship;
                student.TotalCredit = entity.TotalCredit;
                student.IsPayment = entity.IsPayment;
                student.IsGraduate = entity.IsGraduate;
                student.RoleId = entity.RoleId;
                student.DepartmentId = entity.DepartmentId;
                student.IsStatus = entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            catch { }
            return result;
        }

        public List<Student> List()
        {
            return db.Student.Where(x => x.IsDelete == false).ToList();
        }
    }
}