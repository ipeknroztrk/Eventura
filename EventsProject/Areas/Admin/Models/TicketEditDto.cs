namespace EventsProject.Areas.Admin.Models
{
    public class TicketEditDto
    {
        public int TicketId { get; set; }  // Güncellenecek biletin ID'si
        public int? EventsTicketId { get; set; }  // Etkinlik bileti ID'si (eventsTicket ile ilişkili)
        public string TicketNumber { get; set; }  // Bilet numarası
        public bool IsAvailable { get; set; }  // Biletin mevcut durumu (Satılabilir veya Satılmamış)
        public int? UserId { get; set; }  // Biletin sahip olduğu kullanıcı ID'si (Nullable, atanmamış olabilir)
        public int EventId { get; set; }  // Etkinlik ID'si (event ile ilişkili)
    }

}
