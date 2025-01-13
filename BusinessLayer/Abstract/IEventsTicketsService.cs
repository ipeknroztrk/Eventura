using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IEventsTicketsService : IGenericService<EventsTickets>
    {
        
        List<EventsTickets> TGetList(); 
        void TAdd(EventsTickets t); 
        List<Ticket> GetTicketsByEventsTicketId(int eventsTicketId);
        List<EventsTickets> GetEventsTicketsByEventId(int eventId); 



    }
}
