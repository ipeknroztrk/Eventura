using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace EventsProject.ViewComponents
{
    public class _UILayoutUpcomingEventsComponent : ViewComponent
    {

        Context db = new Context();


        public IViewComponentResult Invoke()
        {
            // Son 8 etkinliği tarihe göre sıralayarak al
            var upcomingEvents = db.Events
                .OrderByDescending(e => e.EventDate) // En yeni tarih sıralaması
                .Take(8) // Son 8 etkinlik
                .OrderBy(e => e.EventDate) // Yeniden tarihe göre sıralama (küçükten büyüğe)
                .ToList();

            return View(upcomingEvents); // Modeli View'e gönder
        }
    }
}
