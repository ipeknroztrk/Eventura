public class EventViewModel
{
    public int TicketId { get; set; }
    public string TicketNumber { get; set; }
    public bool IsAvailable { get; set; }

    public int EventId { get; set; }
    public string EventName { get; set; }
    public string EventCategory { get; set; }
    public string EventArtist { get; set; }
    public DateTime EventDate { get; set; }
    public string EventLocation { get; set; }
}
