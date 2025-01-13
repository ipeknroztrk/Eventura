namespace EventsProject.Models
{
    public class PaymentViewModel
    {
        public int EventId { get; set; }
        public int EventTicketId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public bool SaveCard { get; set; }
        public int? SelectedCardId { get; set; }
        public decimal Price { get; set; }
    }


}