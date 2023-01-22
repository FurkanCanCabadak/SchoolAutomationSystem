using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class AdminPartialController : Controller
    {
        AdminRepository adminRepository= new AdminRepository();
        // GET: AdminPartial
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