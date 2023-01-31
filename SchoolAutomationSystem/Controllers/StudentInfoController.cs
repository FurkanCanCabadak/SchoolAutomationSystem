using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        StudentRepository studentRepository= new StudentRepository();
        // GET: StudentInfo
        public ActionResult Index()
        {
            return View();
        }
    }
}