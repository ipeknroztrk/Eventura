using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Payment
    {
        public int PaymentId { get; set; }   // Birincil anahtar
        public int TicketId { get; set; }     // Bilet ID'si

        public int UserId { get; set; }
        public string PaymentStatus { get; set; } 
        public decimal Amount { get; set; }   // Ödenen tutar
        public DateTime PaymentDate { get; set; } // Ödeme tarihi
        public int? SavedCardId { get; set; }

        // İlişkiler
        public virtual Ticket Ticket { get; set; }

        public virtual AppUser User { get; set; }

        public virtual SavedCard SavedCard { get; set; }
    }

}
