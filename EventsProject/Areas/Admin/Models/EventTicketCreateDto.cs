namespace EventsProject.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

    public class EventTicketCreateDto
    {
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public int TicketCapacity { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }  // UserId'yi nullable hale getirin
}

