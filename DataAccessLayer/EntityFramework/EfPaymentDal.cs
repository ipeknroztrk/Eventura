using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore; // EF Core kullanıyoruz
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPaymentDal : GenericRepository<Payment>, IPaymentDal
    {
        public async Task<bool> BuyTicketAsync(int eventId, int userId, int eventTicketId)
        {
            try
            {
                using (var context = new Context())
                {
                    // Transaction başlatıyoruz
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Önce EventsTickets tablosundan ilgili kaydı bulalım
                            var eventTicket = await context.EventsTickets
                                .FirstOrDefaultAsync(et => et.EventId == eventId && et.EventsTicketId == eventTicketId);

                            if (eventTicket == null)
                            {
                                throw new Exception("Event ticket bulunamadı.");
                            }

                            // Uygun bir bilet bulmaya çalışıyoruz - eventTicketId'ye göre filtreleme eklendi
                            var ticket = await context.Tickets
                                .Where(t => t.EventId == eventId &&
                                          t.EventsTicketId == eventTicketId &&
                                          t.UserId == null &&
                                          t.IsAvailable)
                                .OrderBy(t => t.TicketId)
                                .FirstOrDefaultAsync();

                            if (ticket == null)
                            {
                                throw new Exception("Uygun bilet bulunamadı.");
                            }

                            // SoldCount'u artır
                            eventTicket.SoldCount++;
                            context.EventsTickets.Update(eventTicket);

                            // Biletin durumunu güncelle
                            ticket.UserId = userId;
                            ticket.IsAvailable = false;

                            context.Tickets.Update(ticket);

                            // Değişiklikleri kaydet
                            await context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception($"Bilet satın alma işlemi sırasında bir hata oluştu: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"BuyTicketAsync genel hata: {ex.Message}");
            }
        }


        public decimal GetEventTicketPrice(int id)
        {
            using (var context = new Context())
            {
                // EventId ile EventTickets tablosundan fiyatı alıyoruz
                var price = context.EventsTickets
                    .Where(et => et.EventId == id)
                    .Select(et => et.Price)
                    .FirstOrDefault();

                return price;
            }
        }
    }
}