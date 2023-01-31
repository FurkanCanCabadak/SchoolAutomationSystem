using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentAffairPaymentController : Controller
    {
        DataAccess db = new DataAccess();
        StudentRepository studentRepository= new StudentRepository();
        // GET: StudentAffairPayment
        public ActionResult Index()
        {
            var students= db.Student.Where(x=>x.IsStatus==true&&x.IsPayment==true).ToList();
            return View(students);
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
            TempData["Message"] = studentRepository.PaymentSA(student) ?
                                   "Student Pay Successful" :
                                   "Student Pay Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Delete(int id)
        {
            var student = studentRepository.Detail(id);
            if (student != null)
            {
                student.IsPayment= false;
                studentRepository.Edit(student);
            }
            return RedirectToAction("Index");
        }
    }
}