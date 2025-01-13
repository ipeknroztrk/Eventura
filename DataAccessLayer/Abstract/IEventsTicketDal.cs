using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEventsTicketDal: IGenericDal<EventsTickets>
    {
        List<EventsTickets> GetEventsTicketsByEventId(int eventId);
        List<EventsTickets> GetList();
        List<Ticket> GetTicketsByEventsTicketId(int eventsTicketId);


    }
}
