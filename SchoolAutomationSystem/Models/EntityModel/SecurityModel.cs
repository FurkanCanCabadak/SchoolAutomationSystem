using SchoolAutomationSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class SecurityModel
    {
        DataAccess db = new DataAccess();

        public int Login(string UserName, string Password, string Remember)
        {
            bool remem = Remember == "on" ? true : false;
            var admin = db.Admin.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            int result = 0;
            if (admin != null)
            {
                if (admin.IsStatus == true && admin.IsDelete == false)
                {
                    FormsAuthentication.SetAuthCookie(UserName, remem);
                    result = 1;
                }
                
                else if (admin.IsStatus == false)
                {
                    result = 3;
                }
                else if (admin.IsDelete == true)
                {
                    result = 4;
                }
            }
            

            return result;
        }
        public int LoginStudent(string UserName, string Password, string Remember)
        {
            bool remem = Remember == "on" ? true : false;
            var student = db.Student.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            int result = 0;
            if (student != null)
            {
                if (student.IsStatus == true && student.IsDelete == false)
                {
                    FormsAuthentication.SetAuthCookie(UserName, remem);
                    
                    result = 1;
                }

                else if (student.IsStatus == false)
                {
                    result = 3;
                }
                else if (student.IsDelete == true)
                {
                    result = 4;
                }
            }


            return result;
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}