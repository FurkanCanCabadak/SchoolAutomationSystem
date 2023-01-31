using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolAutomationSystem.Controllers
{
    public class HomeController : Controller
    {
        SecurityModel security = new SecurityModel();
        public ActionResult Index()
        {
            if (Roles.IsUserInRole(User.Identity.Name, "Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (Roles.IsUserInRole(User.Identity.Name, "Teacher"))
            {
                return RedirectToAction("Index", "Teacher");
            }
            else if (Roles.IsUserInRole(User.Identity.Name, "StudentAffair"))
            {
                return RedirectToAction("Index", "StudentAffair");
            }
            else 
            { 
                return RedirectToAction("Index","Student"); 
            }
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password, string Remember)
        {
            int result = security.Login(UserName, Password, Remember);
            ViewBag.Message = result == 0 ?
                            "Öğrenci ismi veya Şifre Hatalı." :
                            result == 2 ?
                            "Hesap Aktif Değil. Aktivasyon Kodu ile Aktifleştiriniz." :
                            result == 4 ?
                            "Hesap Silinmiştir. Lütfen Farklı Bir Hesap Deneyiniz." : "Giriş Başarılı";
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Logout()
        {
            security.Logout();
            return RedirectToAction("Login");
        }
    }
}