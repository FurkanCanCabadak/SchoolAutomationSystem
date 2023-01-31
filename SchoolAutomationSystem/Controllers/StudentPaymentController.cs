using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentPaymentController : Controller
    {
        StudentRepository studentRepository=new StudentRepository();
        // GET: StudentPayment
        public ActionResult Index()
        {
            var student = studentRepository.DetailwithName(User.Identity.Name); 
            return View(student);
        }
        public ActionResult Edit(int id)
        {
            var student = studentRepository.Detail(id);
            if (student != null)
            {

                return View(student);
            }
            TempData["Message"] = "Not Found Student";
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            TempData["Message"] = studentRepository.Payment(student) ?
                                   "Student Pay Successful" :
                                   "Student Pay Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}