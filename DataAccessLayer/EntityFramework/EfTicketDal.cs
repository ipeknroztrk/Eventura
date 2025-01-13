using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.EntityFramework
{
    public class EfTicketDal : GenericRepository<Ticket>, ITicketDal
    {
        public void AddRange(IEnumerable<Ticket> tickets)
        {
            using var c = new Context();
            c.Set<Ticket>().AddRange(tickets);
            c.SaveChanges();
        }
        public void DeleteRange(List<Ticket> tickets)
        {
            using var c = new Context();
            c.Tickets.RemoveRange(tickets);
            c.SaveChanges();
        }

        public IQueryable<Ticket> GetQueryable()
        {
            throw new NotImplementedException();
        }
        public IQueryable<Ticket> GetListAll(Expression<Func<Ticket, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null
                    ? context.Set<Ticket>()
                    : context.Set<Ticket>().Where(filter);
            }
        }

        public IEnumerable<Ticket> GetTicketsWithIncludes(int eventsTicketId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketsByEventsTicketId(int eventsTicketId)
        {
            using (var context = new Context())
            {
                return context.Tickets
                    .Where(t => t.EventsTicketId == eventsTicketId)
                    .Include(t => t.User)
                    .Include(t => t.Payment) // Ödemeyi dahil ediyoruz
                    .ToList();
            }
        }

    }
}