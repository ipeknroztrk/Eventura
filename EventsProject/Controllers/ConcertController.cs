using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventsProject.Controllers
{
    public class ConcertController : Controller
    {

        private readonly IPaymentService paymentService;

        public ConcertController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        Context db = new Context();
        public IActionResult Index()
        {
            ViewBag.WelcomeMessage = TempData["WelcomeMessage"];
            var values = db.Events.Where(x => x.CategoryId == 1).ToList();
            return View(values);
        }

       
        public IActionResult Details(int id)
        {
            var eventDetail = db.Events.FirstOrDefault(x => x.EventId == id);
            if (eventDetail == null)
            {
                return NotFound("Etkinlik bulunamadı.");
            }

         
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
  
            var userExists = db.Users.Any(x => x.Id == userId);
            if (!userExists)
            {
                return Json(new { success = false, message = "Geçersiz kullanıcı." });
            }

            var eventExists = db.Events.Any(x => x.EventId == eventId.Value);
            if (!eventExists)
            {
                return Json(new { success = false, message = "Etkinlik bulunamadı." });
            }

          
            var existingFavorite = db.UserFavorites
                .Any(x => x.UserId == userId && x.EventId == eventId.Value);

            if (existingFavorite)
            {
                return Json(new { success = false, message = "Bu etkinlik zaten favorilerinizde." });
            }

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