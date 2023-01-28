using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class AdminDepartmentController : Controller
    {
        DataAccess db = new DataAccess();
        FacultyRepository facultyRepository = new FacultyRepository();
        DepartmentRepository departmentRepository = new DepartmentRepository();
        // GET: AdminDepartment
        public ActionResult Index()
        {
            var model = new DepartmentFaculty();
            model.DepartmentList = departmentRepository.List();
            model.FacultyList = facultyRepository.List();

            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Department department)
        {
            TempData["Message"] = departmentRepository.Add(department) ?
                                  "Department Add Successful" : "Department Add Failed";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            TempData["Message"] = departmentRepository.Delete(id) ?
                                  "Department Delete Successful" : "Department Delete Failed";
            return RedirectToAction("Index");
        }
    }
}