using Microsoft.AspNetCore.Mvc;

namespace EventsProject.ViewComponents
{
    public class _UILayoutScriptComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
