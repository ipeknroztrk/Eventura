namespace EventsProject.Areas.Admin.Models;

public class TicketDetailDto
{
    public int TicketId { get; set; }
    public string TicketNumber { get; set; }
    public bool IsAvailable { get; set; }
    public string UserName { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public decimal Price { get; set; }
}