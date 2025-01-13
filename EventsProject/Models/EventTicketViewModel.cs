namespace EventsProject.Models
{
    public class EventTicketViewModel
    {
        public int EventTicketId { get; set; }
        public int EventId { get; set; }
        public int SoldCount { get; set; }
        public decimal Price { get; set; }
    }

}