using SchoolAutomationSystem.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        SecurityModel security = new SecurityModel();
        public ActionResult Index()
        {
            return View();
        }
        
    }
}