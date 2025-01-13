using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;
using Newtonsoft.Json;


namespace EventsProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;

        private readonly ILogger<ArtistController> _logger; // Logger'ı ekliyoruz

        // Constructor üzerinden ICategoryService ve ILogger<CategoriesController> enjeksiyonunu yapıyoruz


        public ArtistController(IArtistService artistService, ILogger<ArtistController> logger)
        {
            _artistService = artistService;
            _logger = logger;

        }

        public IActionResult Index()
        {
            try
            {
                var values = _artistService.TGetList(); 
                return View(values); // artistleri View'e gönder
            }
            catch (Exception ex)
            {
                _logger.LogError($"Artist listeleme hatası: {ex.Message}"); // Hata mesajını log'a yazdırıyoruz
                return View("Error");
            }

        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            _artistService.TAdd(artist);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var artist = _artistService.TGetByID(id);
            if (artist == null)
            {
                _logger.LogError($"ID ile eşleşen sanatçı bulunamadı. ID: {id}");
                return NotFound();
            }

            return View(artist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Artist artist)
        {
            // Events alanını doğrulamadan kaldırıyoruz
            ModelState.Remove("Events");

            if (ModelState.IsValid)
            {
                try
                {
                    // Sanatçıyı güncelle
                    _artistService.TUpdate(artist);

                    // Başarı mesajı
                    TempData["SuccessMessage"] = "Sanatçı başarıyla güncellendi.";

                    // Liste sayfasına yönlendir
                    return RedirectToAction("Index"); 
                }
                catch (Exception ex)
                {
                    // Hata mesajını log'a yazdır
                    _logger.LogError($"Sanatçı güncelleme hatası: {ex.Message}");

                    // Kullanıcıya hata mesajı göster
                    TempData["ErrorMessage"] = "Bir hata oluştu.";
                }
            }

            TempData["ErrorMessage"] = "Geçersiz form verisi.";
            return View(artist);
        }


        public IActionResult Delete(int id)
        {
            var value = _artistService.TGetByID(id);
            if (value != null)
            {
                _artistService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var artist = _artistService.TGetByID(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }
    }
}
