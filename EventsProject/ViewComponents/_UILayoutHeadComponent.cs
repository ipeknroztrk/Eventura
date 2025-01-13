using System;
using Microsoft.AspNetCore.Mvc;


namespace EventsProject.ViewComponents
{
    public class _UILayoutHeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
