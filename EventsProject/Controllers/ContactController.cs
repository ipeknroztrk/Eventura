using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete; // Message modelini içeri aktarmak için
using DataAccessLayer.Concrete; // DbContext'i içeri aktarmak için

namespace EventsProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly Context _context;

        // Constructor üzerinden DbContext'i alıyoruz
        public ContactController(Context context)
        {
            _context = context;
        }

        // GET isteği, formu döndürüyor
        public IActionResult Index()
        {
            return View();
        }

        // POST isteği, form verilerini alıp veritabanına kaydediyor
        [HttpPost]
        public IActionResult Index(Message message)
        {
            if (ModelState.IsValid)
            {
                // Mesajı veritabanına ekliyoruz
                _context.Messages.Add(message);
                _context.SaveChanges();

                // Kullanıcıya başarı mesajı gösteriyoruz
                TempData["Success"] = "Mesajınız başarıyla gönderildi!";

                // Modal'ı görüntülemek için kullanıcıyı yönlendiriyoruz
                return RedirectToAction("Index");  // Aynı sayfaya yönlendiriyoruz
            }

            // Hata durumu
            TempData["Error"] = "Mesaj gönderilirken bir hata oluştu.";
            return View(message);
        }
    }
}
