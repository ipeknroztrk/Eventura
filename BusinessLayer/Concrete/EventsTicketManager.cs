using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class EventsTicketManager : IEventsTicketsService
    {
        private readonly IEventsTicketDal _eventsTicketDal;

        public EventsTicketManager(IEventsTicketDal eventsTicketDal)
        {
            _eventsTicketDal = eventsTicketDal;
        }

        public List<EventsTickets> GetEventTicketsWithEvents()
        {
            throw new NotImplementedException();
        }

        public void TAdd(EventsTickets t)
        {
            _eventsTicketDal.Insert(t); 
        }

        public void TDelete(EventsTickets t)
        {
            _eventsTicketDal.Delete(t);
        }

        public EventsTickets TGetByID(int id)
        {
            return _eventsTicketDal.GetByID(id); 
        }

        
        public List<EventsTickets> TGetList()
        {
            return _eventsTicketDal.GetList();  
        }

        public void TUpdate(EventsTickets t)
        {
            _eventsTicketDal.Update(t); 
        }

        public List<Ticket> GetTicketsByEventsTicketId(int eventsTicketId)
        {
            
            return _eventsTicketDal.GetTicketsByEventsTicketId(eventsTicketId);
        }
        
        public List<EventsTickets> GetEventsTicketsByEventId(int eventId)
        {
            return _eventsTicketDal.GetEventsTicketsByEventId(eventId);
        }









    }
}
