using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EventsProject.ViewComponents
{
    public class _UILayoutArtistComponent : ViewComponent
    {
        Context db = new Context();
        public IViewComponentResult Invoke()
        {
            var values = db.Artists.ToList();
            return View(values);
        }
    }
}
