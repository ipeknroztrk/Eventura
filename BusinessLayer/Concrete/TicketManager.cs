using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class TicketManager : ITicketService
    {
        private readonly ITicketDal _ticketDal;

        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }

        public void TAdd(Ticket t)
        {
            
            _ticketDal.Add(t);
        }

        public void TDelete(Ticket t)
        {
           
            _ticketDal.Delete(t);
        }

        public Ticket TGetByID(int id)
        {
           
            return _ticketDal.GetByID(id);
        }

        public List<Ticket> TGetList()
        {
          
            return _ticketDal.GetList();
        }

        public void TUpdate(Ticket t)
        {
            
            _ticketDal.Update(t);
        }

       
        public void TAddRange(IEnumerable<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                _ticketDal.Add(ticket);
            }
        }

        public void TDeleteRange(List<Ticket> tickets)
        {
            if (tickets == null || !tickets.Any())
            {
                return; // No tickets to delete
            }

            try
            {
                // Use the repository's DeleteRange method
                _ticketDal.DeleteRange(tickets);
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to use a logging framework)
                Console.WriteLine($"Error deleting tickets: {ex.Message}");
                throw; // Re-throw to allow calling method to handle
            }
        }

        public IEnumerable<Ticket> GetTicketsByEventsTicketId(int eventsTicketId)
        {
       
            return _ticketDal.GetTicketsByEventsTicketId(eventsTicketId);
        }
    }
}
