using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentController : Controller
    {
        SecurityModel security = new SecurityModel();
        StudentRepository studentRepository= new StudentRepository();
        // GET: Student
        public ActionResult Index()
        {
            return View(studentRepository.DetailwithName(User.Identity.Name));
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password, string Remember)
        {
            int result = security.LoginStudent(UserName, Password, Remember);
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
            return RedirectToAction("Login","Student");
        }
    }
}