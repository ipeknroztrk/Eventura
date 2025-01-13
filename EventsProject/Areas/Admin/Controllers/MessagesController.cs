using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService; // IMessageService inject ediyoruz
        private readonly ILogger<MessagesController> _logger; // Logger

        // Constructor ile IMessageService ve ILogger enjeksiyonu yapıyoruz
        public MessagesController(IMessageService messageService, ILogger<MessagesController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        // Mesajları listeleme
        public IActionResult Index()
        {
            try
            {
                var messages = _messageService.TGetList(); // Mesajları alıyoruz
                return View(messages); // Mesajları view'a gönderiyoruz
            }
            catch (Exception ex)
            {
                _logger.LogError($"Mesaj listeleme hatası: {ex.Message}");
                return View("Error");
            }
        }

       

        // Mesaj detaylarını gösterme
        public IActionResult Details(int id)
        {
            var message = _messageService.TGetByID(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }
    }
}
