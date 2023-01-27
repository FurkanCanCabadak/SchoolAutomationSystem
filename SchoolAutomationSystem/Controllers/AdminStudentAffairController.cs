using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    [RoutePrefix("AdminStudentAffair")]
    [Route("{action=Index}")]
    public class AdminStudentAffairController : Controller
    {
        StudentAffairRepository affairRepository = new StudentAffairRepository();
        // GET: AdminStudentAffair
        public ActionResult Index()
        {
            return View(affairRepository.List());
        }
        public ActionResult Delete(int id)
        {
            TempData["Message"] = affairRepository.Delete(id) ?
                                    "Students Affair Personal Deleted Successful" :
                                    "Students Affair Personal Deletion Failed";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(StudentAffair studentAffair)
        {

            TempData["Message"] = affairRepository.Add(studentAffair) ?
                                    "Students Affair Personal Added Successful" :
                                    "Students Affair Personal Insert Failed";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("~/AdminStudentAffair/Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var studentAffair = affairRepository.Detail(id);
            if (studentAffair != null)
            {
                
                return View(studentAffair);
            }
            TempData["Message"] = "Not Found Students Affair Personal";
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("~/AdminStudentAffair/Edit/{id:int}")]
        public ActionResult Edit(StudentAffair studentAffair)
        {
            TempData["Message"] = affairRepository.Edit(studentAffair) ?
                                   "Students Affair Personal Edit Successful" :
                                   "Students Affair Personal Edit Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}