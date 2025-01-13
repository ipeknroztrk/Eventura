using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using EventsProject.Controllers;

namespace EventsProject.Controllers
{

    public class SavedCardController : Controller
    {
        private readonly Context _context;
        private readonly IGenericService<SavedCard> _savedCardService;

        public SavedCardController(Context context, IGenericService<SavedCard> savedCardService)
        {
            _context = context;
            _savedCardService = savedCardService;
        }

        [HttpGet]
        public IActionResult GetSavedCards()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized();

            var savedCards = _context.SavedCards
                .Where(c => c.UserId.ToString() == userIdString)
                .Select(c => new
                {
                    c.SavedCardId,
                    CardNumber = "**** **** **** " + c.CardNumber.Substring(c.CardNumber.Length - 4),
                    c.CardHolderName,
                    ExpiryDate = c.ExpiryDate.ToString("MM/yy"),
                    CVV = c.CVV // CVV'yi de ekledik
                })
                .ToList();

            return Json(savedCards);
        }

        [HttpGet]
        public IActionResult GetCardCVV(int cardId)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString))
                return Unauthorized();

            var card = _context.SavedCards
                .FirstOrDefault(c => c.SavedCardId == cardId && c.UserId.ToString() == userIdString);

            if (card == null)
                return NotFound();

            return Json(new { cvv = card.CVV });
        }
    }
}
