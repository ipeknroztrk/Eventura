using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class EventEventsTickets
{
    [Key]
    public int EventId { get; set; } // kendi id'si

    [Key]
    public int EventsTicketsEventsTicketId { get; set; } // Event tablosundan alınan EventId

    // Event ile ilişkiyi belirtiyoruz
    public virtual Event Event { get; set; }  // EventId ile bağlantılı Event nesnesi
    public virtual EventsTickets EventsTickets { get; set; } // Ticket ile ilişki
}
