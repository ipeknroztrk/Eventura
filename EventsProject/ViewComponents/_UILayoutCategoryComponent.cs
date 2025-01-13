using System;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace EventsProject.ViewComponents
{
    public class _UILayoutCategoryComponent:ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
    }
}
