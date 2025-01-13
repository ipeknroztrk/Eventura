using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using System.Linq;


        

namespace DataAccessLayer.EntityFramework
    {
        public class EfEventsTicketDal : GenericRepository<EventsTickets>, IEventsTicketDal
        {
        // Burada manuel olarak context'i kullanıyoruz.
        public List<EventEventsTickets> GetList()
        {
            using (var context = new Context())
            {
                return context.EventEventsTicket
                    .Include(e => e.Event) // Event ile ilişkiyi yükle
                    .ToList();
            }
        }
        public List<Ticket> GetTicketsByEventsTicketId(int eventsTicketId)
        {
            using (var context = new Context())
            {
                // Retrieve Tickets where the EventsTicketId matches
                return context.Tickets
                    .Where(t => t.EventsTicketId == eventsTicketId)
                    .ToList();
            }
        }
        




        public List<EventsTickets> GetEventsTicketsByEventId(int eventId)
            {
                using (var context = new Context())
                {
                    // Belirli bir EventId'ye göre EventsTickets döndürüyoruz
                    return context.EventsTickets
                        .Where(et => et.EventId == eventId)
                        .Include(et => et.Events) // İlişkili Events verisini yükle
                        .Include(et => et.Tickets) // İlişkili Tickets verisini yükle
                        .ToList();
                }
            }

            public List<string> GetTicketNames()
            {
                using (var context = new Context())
                {
                    // Ticket isimlerini döndürüyoruz
                    return context.EventsTickets
                        .Select(et => et.Name)
                        .ToList();
                }
            }

        






    }
}

