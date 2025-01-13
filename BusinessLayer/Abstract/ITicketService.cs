using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ITicketService : IGenericService<Ticket>
    {
        
        void TAddRange(IEnumerable<Ticket> tickets);
        void TDeleteRange(List<Ticket> tickets);
        IEnumerable<Ticket> GetTicketsByEventsTicketId(int eventsTicketId);
    }
}
