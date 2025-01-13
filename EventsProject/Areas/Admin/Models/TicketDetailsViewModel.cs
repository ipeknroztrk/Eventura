using EntityLayer.Concrete;

namespace EventsProject.Areas.Admin.Models;


public class TicketDetailsViewModel
{
    public EventsTickets EventsTicket { get; set; }
    public string EventTitle { get; set; }
    public List<TicketDetailDto> Tickets { get; set; }
}