using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventsProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
       
            private readonly ICategoryService _categoryService;
            private readonly IEventService _eventService;
            private readonly IArtistService _artistService;

            public EventsController(ICategoryService categoryService, IEventService eventService, IArtistService artistService)
            {
                _categoryService = categoryService;
                _eventService = eventService;
                _artistService = artistService;
            }
        



        public ActionResult Index()
        {
            var events = _eventService.TGetListWithArtistAndCategory(); 
            return View(events); 
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Artists = _artistService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Event eventObj)
        {
           
               
                _eventService.TAdd(eventObj); 

                return RedirectToAction("Index");
           
          
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
              
                var eventToDelete = _eventService.TGetByID(id); 
                if (eventToDelete != null)
                {
                    
                    _eventService.TDelete(eventToDelete);
                    TempData["SuccessMessage"] = "Etkinlik başarıyla silindi!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Etkinlik bulunamadı!";
                }

               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Silme işlemi başarısız: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
           
                var eventDetails = _eventService.TGetByIDWithArtistAndCategory(id);

               
                

               
                ViewBag.ArtistName = eventDetails.Artist?.Name ?? "Sanatçı bilgisi yok";
                ViewBag.CategoryName = eventDetails.Category?.Name ?? "Kategori bilgisi yok";

                // Etkinlik bilgilerini view'e gönderiyoruz
                return View(eventDetails);
           
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = _eventService.TGetByID(id);
            if (eventToEdit == null)
            {
                TempData["ErrorMessage"] = "Etkinlik bulunamadı!";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Artists = _artistService.GetAll();
            return View(eventToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event eventObj)
        {

            var existingEvent = _eventService.TGetByID(eventObj.EventId);
           
                // Mevcut veriyi günceller.
                existingEvent.Title = eventObj.Title;
                existingEvent.Description = eventObj.Description;
            existingEvent.EventDate = eventObj.EventDate.ToUniversalTime();

            existingEvent.Location = eventObj.Location;
                existingEvent.ImageUrl = eventObj.ImageUrl;
                existingEvent.LocationUrl = eventObj.LocationUrl;
                existingEvent.Details = eventObj.Details;
                existingEvent.CategoryId = eventObj.CategoryId;
                existingEvent.ArtistId = eventObj.ArtistId;

                _eventService.TUpdate(existingEvent); // Güncelleme işlemi.
                TempData["SuccessMessage"] = "Etkinlik başarıyla güncellendi!";
                return RedirectToAction("Index");

            
        }

    }
}