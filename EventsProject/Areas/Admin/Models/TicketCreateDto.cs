namespace EventsProject.Areas.Admin.Models
{
    public class TicketCreateDto
    {
        public int EventsTicketId { get; set; }
        public string TicketNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int? UserId { get; set; }  // UserId nullable olmalı
        public int EventId { get; set; }
    }

}
