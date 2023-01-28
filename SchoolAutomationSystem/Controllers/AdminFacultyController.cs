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
    public class AdminFacultyController : Controller
    {
        DataAccess db = new DataAccess();
        FacultyRepository facultyRepository= new FacultyRepository();
        // GET: AdminFaculty
        public ActionResult Index()
        {
            return View(facultyRepository.List());
        }
        [HttpPost]
        public ActionResult Add(Faculty faculty)
        {

            TempData["Message"] = facultyRepository.Add(faculty) ?
                                    "Faculty Added Successful" :
                                    "Faculty Insert Failed";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var faculty = facultyRepository.Detail(id);
            if (faculty != null)
            {
                return View(faculty);
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Faculty faculty)
        {
            ViewBag.Message = facultyRepository.Edit(faculty) ?
                                   "Faculty Edit Successful" :
                                   "Faculty Edit Failed";

            return View(facultyRepository.Detail(faculty.Id));
        }
        public ActionResult Delete(int id)
        {
            TempData["Message"] = facultyRepository.Delete(id) ?
                                    "Faculty Deleted Successful" :
                                    "Faculty Deletion Failed";

            return RedirectToAction("Index");
        }
    }
}