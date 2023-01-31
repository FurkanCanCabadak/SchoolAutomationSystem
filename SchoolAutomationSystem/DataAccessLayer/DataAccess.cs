using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.DataAccessLayer
{
    public class DataAccess:DbContext
    {
        private static List<User> User = new List<User>();
        public DataAccess() : base("DbConnection") { }
        public DbSet<Role> Role { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<StudentAffair> StudentAffair { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<SelectionLesson> SelectionLesson { get; set; }
        public DbSet<Note> Note { get; set; }
        public void FillUser()
        {
            foreach (var item in StudentAffair)
            {
                User user = new User()
                {
                    UserName = item.UserName,
                    Password = item.Password,
                    IsDelete = item.IsDelete,
                    RoleId = item.RoleId,
                    IsStatus = item.IsStatus,
                };
                User.Add(user);
            }
            foreach (var item in Student)
            {
                User user = new User()
                {
                    UserName = item.UserName,
                    Password = item.Password,
                    IsDelete = item.IsDelete,
                    RoleId = item.RoleId,
                    IsStatus = item.IsStatus,
                };
                User.Add(user);
            }
            foreach (var item in Teacher)
            {
                User user = new User()
                {
                    UserName = item.UserName,
                    Password = item.Password,
                    IsDelete = item.IsDelete,
                    RoleId = item.RoleId,
                    IsStatus = item.IsStatus,
                };
                User.Add(user);
            }
            foreach (var item in Admin)
            {
                User user = new User()
                {
                    UserName = item.UserName,
                    Password = item.Password,
                    IsDelete = item.IsDelete,
                    RoleId = item.RoleId,
                    IsStatus = item.IsStatus,
                };
                User.Add(user);
            }
        }
        public List<User> GetUser()
        {
            return User;
        }
    }
}