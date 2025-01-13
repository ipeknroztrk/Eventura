using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccessLayer.Abstract
{
    public interface ITicketDal : IGenericDal<Ticket>
    {
        void DeleteRange(List<Ticket> tickets);
        IQueryable<Ticket> GetListAll(Expression<Func<Ticket, bool>> filter = null);
        IEnumerable<Ticket> GetTicketsByEventsTicketId(int eventsTicketId);


    }
}
