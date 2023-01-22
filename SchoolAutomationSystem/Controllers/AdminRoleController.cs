using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{

    public class AdminRoleController : Controller
    {
        // GET: AdminRole
        RoleRepository roleRepository = new RoleRepository();
        public ActionResult Index()
        {
            return View(roleRepository.List());
        }

        public ActionResult Delete(int id)
        {
            TempData["Message"] = roleRepository.Delete(id) ?
                                    "Role Deleted Successful" :
                                    "Role Deletion Failed";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(Role role)
        {

            TempData["Message"] = roleRepository.Add(role) ?
                                    "Role Added Successful" :
                                    "Role Insert Failed";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var role = roleRepository.Detail(id);
            if (role != null)
            {
                return View(role);
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            ViewBag.Message = roleRepository.Edit(role) ?
                                   "Role Edit Successful" :
                                   "Role Edit Failed";

            return View(roleRepository.Detail(role.Id));
        }

    }
}