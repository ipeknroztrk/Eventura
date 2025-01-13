using BusinessLayer.Abstract;
using EventsProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventsProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService _eventService;

        public HomeController(IEventService eventService, ILogger<HomeController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var eventDetails = _eventService.TGetByID(id);
            if (eventDetails == null)
            {
                return NotFound();
            }

            return View(eventDetails); // Etkinlik detaylarý için view'a gönderiyoruz
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}