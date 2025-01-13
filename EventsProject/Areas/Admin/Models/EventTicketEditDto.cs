using System.ComponentModel.DataAnnotations;
namespace EventsProject.Areas.Admin.Models;

public class EventTicketEditDto
{
    public int EventsTicketId { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int TicketCapacity { get; set; }
    public int? UserId { get; set; }  // UserId'yi nullable hale getirin
}
