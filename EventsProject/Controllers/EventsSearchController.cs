using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using System.Collections.Generic;
using DataAccessLayer.Concrete;

namespace EventProject.Controllers
{
    public class EventSearchController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;


        public EventSearchController(IEventService eventService, ICategoryService categoryService, ICityService cityService, Context context)
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _cityService = cityService;
            db = context;
        }

        private readonly Context db; // DbContext'inizin adı




        public IActionResult Details(int id)
        {
            var eventDetail = db.Events.FirstOrDefault(x => x.EventId == id);
            if (eventDetail == null)
            {
                return NotFound();
            }
            return View(eventDetail);
        }

        [HttpGet]
        public IActionResult Index(int? cityId, int? categoryId)
        {
            // Şehir adları al
            var cityNames = _cityService.GetCityNames();

            // Kategori adlarını ve ID'lerini al
            var categories = _categoryService.GetCategories(); // ID ve adları birlikte dönen bir metot olmalı

            // ViewBag'e gönder
            ViewBag.Cities = cityNames;
            ViewBag.Categories = categories;

            // Seçili şehir ve kategori adlarını ayarla
            ViewBag.SelectedCity = cityId.HasValue ? cityNames.ElementAtOrDefault(cityId.Value - 1) : null;
            ViewBag.SelectedCategory = categoryId.HasValue
                ? categories.FirstOrDefault(c => c.CategoryId == categoryId.Value)?.Name
                : null;

            List<Event> events;

            if (cityId.HasValue && categoryId.HasValue)
            {
                events = _eventService.GetEventsByCityAndCategory(cityId.Value, categoryId.Value);
            }
            else if (cityId.HasValue)
            {
                events = _eventService.GetEventsByCity(cityId.Value);
            }
            else if (categoryId.HasValue)
            {
                events = _eventService.GetEventsByCategory(categoryId.Value);
            }
            else
            {
                events = _eventService.TGetList();
            }

            return View(events);
        }



    }
}