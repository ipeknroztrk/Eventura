using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;

namespace EventsProject.ViewComponents
{
    public class _UILayoutSearchComponent : ViewComponent
    {
        Context db = new Context(); // Veritabanı bağlamı

        public IViewComponentResult Invoke()
        {
            // Veritabanından City ve Categories verilerini çekiyoruz
            ViewBag.Cities = db.Cities.ToList();
            ViewBag.Categories = db.Categories.ToList();

            return View();
        }
    }
}
