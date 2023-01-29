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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var department = departmentRepository.Detail(id);
            if (department != null)
            {
                DepartmentFaculty model = new DepartmentFaculty();
                model.DepartmentList= departmentRepository.List();
                model.FacultyList= facultyRepository.List();
                model.SingleDepartment = department;
                model.SingleFaculty = facultyRepository.Detail(department.FacultyId);
            
                return View(model);
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            ViewBag.Message = departmentRepository.Edit(department) ?
                                   "Department Edit Successful" :
                                   "Department Edit Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Delete(int id)
        {
            TempData["Message"] = departmentRepository.Delete(id) ?
                                  "Department Delete Successful" : "Department Delete Failed";
            return RedirectToAction("Index");
        }
    }
}