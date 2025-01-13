using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventsProject.Controllers
{
    public class Stand_UpController : Controller
    {


        private readonly IPaymentService paymentService;

        public Stand_UpController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        Context db = new Context();
        public IActionResult Index()
        {
            var values = db.Events.Where(x => x.CategoryId == 3).ToList();
            return View(values);
        }
        // Detayları Görüntüleme
        public IActionResult Details(int id)
        {
            var eventDetail = db.Events.FirstOrDefault(x => x.EventId == id);
            if (eventDetail == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }

            // Bilet fiyatını almak için GetEventTicketPrice metodunu çağırıyoruz
            decimal ticketPrice = paymentService.GetEventTicketPrice(id);
            ViewBag.TicketPrice = ticketPrice;

            return View(eventDetail);
        }
        [HttpPost]
        public IActionResult AddToFavorites(int? eventId)
        {
            if (eventId == null || eventId == 0)
            {
                return Json(new { success = false, message = "Geçersiz EventId" });
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Kullanıcının geçerli olup olmadığını kontrol et
            var userExists = db.Users.Any(x => x.Id == userId);
            if (!userExists)
            {
                return Json(new { success = false, message = "Geçersiz kullanıcı." });
            }

            // EventId'nin veritabanında var olup olmadığını kontrol et
            var eventExists = db.Events.Any(x => x.EventId == eventId.Value);
            if (!eventExists)
            {
                return Json(new { success = false, message = "Etkinlik bulunamadı." });
            }

            // Kullanıcının bu etkinliği daha önce favorilerine ekleyip eklemediğini kontrol et
            var existingFavorite = db.UserFavorites
                .Any(x => x.UserId == userId && x.EventId == eventId.Value);

            if (existingFavorite)
            {
                return Json(new { success = false, message = "Bu etkinlik zaten favorilerinizde." });
            }

            // Eğer daha önce eklenmemişse, favorilere ekle
            var userFavorite = new UserFavorite
            {
                UserId = userId,
                EventId = eventId.Value
            };

            db.UserFavorites.Add(userFavorite);
            db.SaveChanges();

            return Json(new { success = true, message = "Etkinlik başarıyla favorilere eklendi." });
        }


    }
}