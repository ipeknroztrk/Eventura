using EventsProject.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(string Username, string Password)
        {
            if (Username == "admin" && Password == "1234")
            {
                // Giriş başarılıysa yönlendirme yapılır
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                // Hatalı giriş mesajı gönderilir
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış!";
                return View();
            }
        }



    }
}