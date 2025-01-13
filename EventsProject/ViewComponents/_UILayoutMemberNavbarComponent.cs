using System;
using Microsoft.AspNetCore.Mvc;

namespace EventsProject.ViewComponents
{
    public class _UILayoutMemberNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}