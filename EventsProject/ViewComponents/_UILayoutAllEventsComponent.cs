using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventsProject.ViewComponents
{
    public class _UILayoutAllEventsComponent:ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke()
        {
            var values = db.Events.ToList();
            return View(values);
        }
    }
}
