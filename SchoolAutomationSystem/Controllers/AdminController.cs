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
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string Password, string Remember)
        {
            int result = security.Login(userName, Password, Remember);
            ViewBag.Message = result == 0 ?
                            "Kullanıcı numarası veya Şifre Hatalı." :
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