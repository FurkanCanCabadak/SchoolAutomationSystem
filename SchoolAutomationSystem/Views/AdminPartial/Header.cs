using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Views.AdminPartial
{
    public class Header : Controller
    {
        public AdminRepository adminRepository = new AdminRepository();
        public ActionResult AdminAccount()
        {
            Admin admin = null;

            if (User.Identity.Name != null)
            {
                admin = adminRepository.AdminAccount(User.Identity.Name);
            }

            return PartialView(admin);
        }
    }
}