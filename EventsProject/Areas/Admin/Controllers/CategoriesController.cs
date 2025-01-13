using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EventsProject.Areas.Admin.Controllers
{
    [Area("Admin")] // Admin alanına ait olduğunu belirtir
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger; // Logger'ı ekliyoruz

        // Constructor üzerinden ICategoryService ve ILogger<CategoriesController> enjeksiyonunu yapıyoruz
        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // Kategorileri listele
        public IActionResult Index()
        {
            try
            {
                var values = _categoryService.TGetList(); // Servis üzerinden kategori listesi alınıyor
                return View(values); // Kategorileri View'e gönder
            }
            catch (Exception ex)
            {
                _logger.LogError($"Kategori listeleme hatası: {ex.Message}"); // Hata mesajını log'a yazdırıyoruz
                return View("Error"); // Hata sayfası gösterilebilir
            }
        }

        // Kategori ekle
        // Kategori ekle (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Kategori güncelle (GET)
        public IActionResult Edit(int id)
        {
            try
            {
                var category = _categoryService.TGetByID(id); // Güncellenecek kategori bilgilerini getirme
                if (category == null)
                {
                    _logger.LogWarning($"Kategori güncelleme için bulunamadı: {id}");
                    return NotFound();
                }

                return View(category); // Kategoriyi düzenleme görünümüne gönder
            }
            catch (Exception ex)
            {
                _logger.LogError($"Kategori düzenleme hatası: {ex.Message}");
                return View("Error");
            }
        }

        // Kategori güncelle (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            // Events alanını doğrulamadan kaldırıyoruz
            ModelState.Remove("Events");

            if (ModelState.IsValid) // Events artık kontrol edilmiyor
            {
                try
                {
                    // Sanatçıyı güncelle
                    _categoryService.TUpdate(category);

                    // Başarı mesajı
                    TempData["SuccessMessage"] = "Kategori başarıyla güncellendi.";

                    // Liste sayfasına yönlendir
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Hata mesajını log'a yazdır
                    _logger.LogError($"Kategori güncelleme hatası: {ex.Message}");

                    // Kullanıcıya hata mesajı göster
                    TempData["ErrorMessage"] = "Bir hata oluştu.";
                }
            }
            else
            {
                // ModelState geçersizse, hataları log'a yazdır
                _logger.LogError($"ModelState Hatası: {string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");
                TempData["ErrorMessage"] = "Geçersiz form verisi.";
            }

            // Hata durumunda tekrar aynı sayfayı render et
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var value = _categoryService.TGetByID(id);
            if (value != null)
            {
                _categoryService.TDelete(value);
            }
            return RedirectToAction("Index");
        }




        // Kategori detayları
        public IActionResult Details(int id)
        {
            try
            {
                var category = _categoryService.TGetByID(id); // Detayları getirme
                if (category == null)
                {
                    _logger.LogWarning($"Kategori detayları bulunamadı: {id}");
                    return NotFound();
                }

                return View(category);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Kategori detayları hatası: {ex.Message}"); // Hata mesajını log'a yazdırıyoruz
                return View("Error");
            }
        }
    }
}