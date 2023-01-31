using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models.Abstract;
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
            db.FillUser();
            var list = db.GetUser();
            bool remem = Remember == "on" ? true : false;
            var admin = list.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
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
        
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}