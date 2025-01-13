using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QRCoder;
using System.Security.Claims;

namespace EventsProject.Controllers
{
    public class PaymentController : Controller
    {
        private readonly Context _context;

        private readonly IGenericService<SavedCard> _savedCardService; // Generic service
        private readonly IPaymentService _paymentService;

        public PaymentController(Context context, IGenericService<SavedCard> savedCardService, IPaymentService paymentService)
        {
            _context = context;
            _savedCardService = savedCardService;
            _paymentService = paymentService;
        }
        [HttpPost]
        public async Task<IActionResult> SaveCard(int eventId, string cardHolderName,
 string cardNumber, string expiryDate, string cvv, bool saveCard,
 decimal price, int? selectedCardId, int eventTicketId)
        {
            try
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                {
                    return BadRequest("Kullanıcı kimliği doğrulanamadı.");
                }

                int? savedCardId = null;

               
                if (selectedCardId.HasValue)
                {
                    var existingCard = await _context.SavedCards
                        .FirstOrDefaultAsync(c => c.SavedCardId == selectedCardId.Value && c.UserId == userId);

                    if (existingCard == null)
                    {
                        return BadRequest("Seçilen kayıtlı kart bulunamadı.");
                    }

                    savedCardId = selectedCardId;
                }
                else
                {
                    string cleanCardNumber = cardNumber?.Replace(" ", "");

                    if (string.IsNullOrEmpty(cleanCardNumber) || !cleanCardNumber.All(char.IsDigit) ||
                        cleanCardNumber.Length != 16)
                    {
                        return BadRequest("Geçersiz kart numarası");
                    }

                    if (!int.TryParse(cvv, out int cvvParsed) || cvv.Length != 3)
                    {
                        return BadRequest("Geçersiz CVV");
                    }

                    if (!DateTime.TryParseExact(expiryDate, new[] { "MM/yy", "MM/yyyy" },
                        null, System.Globalization.DateTimeStyles.None, out DateTime expiryDateParsed))
                    {
                        return BadRequest("Geçersiz son kullanma tarihi formatı");
                    }

                   
                    if (saveCard)
                    {
                        var savedCard = new SavedCard
                        {
                            UserId = userId,
                            CardHolderName = cardHolderName,
                            CardNumber = cleanCardNumber,
                            ExpiryDate = expiryDateParsed.ToUniversalTime(),
                            CVV = cvv
                        };
                        _context.SavedCards.Add(savedCard);
                        await _context.SaveChangesAsync();
                        savedCardId = savedCard.SavedCardId;
                    }
                }

               
                bool isTicketPurchased = await _paymentService.BuyTicketAsync(eventId, userId, eventTicketId);

                if (!isTicketPurchased)
                {
                    return BadRequest("Bilet satın alma işlemi başarısız oldu.");
                }

                var purchasedTicket = await _context.Tickets
                    .FirstOrDefaultAsync(t => t.EventId == eventId &&
                                            t.EventsTicketId == eventTicketId &&
                                            t.UserId == userId &&
                                            !t.IsAvailable);

                if (purchasedTicket == null)
                {
                    return BadRequest("Satın alınan bilet bulunamadı.");
                }

              
                var payment = new Payment
                {
                    TicketId = purchasedTicket.TicketId,
                    UserId = userId,
                    SavedCardId = selectedCardId.HasValue ? selectedCardId : 
                                  (saveCard ? savedCardId : null), 
                    PaymentStatus = "Başarılı",
                    Amount = price,
                    PaymentDate = DateTime.UtcNow
                };

                _paymentService.TAdd(payment);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Bilet alma işleminiz başarıyla tamamlandı!";
               
                return RedirectToAction("Tickets", "Dashboard", new { area = "Member" });

            }
            catch (Exception ex)
            {
                return BadRequest($"Bilet satın alınırken bir hata oluştu: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetSavedCards()
        {
            // Kullanıcı ID'sini Claims'den alıyoruz (Kimlik doğrulama ile bağlantılı)
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized(); // Kullanıcı doğrulaması yapılmamışsa yetkisiz dönebiliriz.
            }

            // SavedCards tablosunda, kullanıcı ID'sine göre kartları filtreliyoruz
            var savedCards = _context.SavedCards
                .Where(c => c.UserId.ToString() == userIdString)
                .Select(c => new
                {
                    c.SavedCardId,
                    CardNumber = "** ** ** " + c.CardNumber.Substring(c.CardNumber.Length - 4), // Kart numarasını maskelemek için
                    c.CardHolderName,
                    ExpiryDate = c.ExpiryDate.ToString("MM/yy") // Son kullanma tarihini uygun formatta döndürmek için
                })
                .ToList();

            return Ok(savedCards); // Kayıtlı kartların listesini döndür
        }
        [HttpPost]
        public IActionResult ProcessPayment(int savedCardId)
        {
            var savedCard = _context.SavedCards
                                    .FirstOrDefault(card => card.SavedCardId == savedCardId);

            if (savedCard != null)
            {
                // Ödeme işlemi mantığını burada yazın.
                return Json(new { success = true, message = "Ödeme başarılı!" });
            }

            return Json(new { success = false, message = "Kart bulunamadı." });
        }

        [HttpGet]
        public IActionResult GenerateQR(int ticketId)
        {
            // Here we simulate the QR code generation logic
            string qrData = $"Ticket-{ticketId}-QR";

            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                // var qrCode = new QRCode(qrCodeData);
                //  var qrCodeImage = qrCode.GetGraphic(20); // Adjust size if necessary

                using (var ms = new System.IO.MemoryStream())
                {
                    // qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    return File(byteImage, "image/png");
                }
            }
        }


    }
}