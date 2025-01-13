using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }  // Birincil anahtar
        public int EventId { get; set; }


        public int? UserId { get; set; }

        public int? EventsTicketId { get; set; }

        public string TicketNumber { get; set; }
        public bool IsAvailable { get; set; } // Biletin durumu (mevcut / satıldı)
        
        


        // İlişkiler

        public virtual Event Event { get; set; }

        public virtual Payment Payment { get; set; }


 

        public virtual AppUser User { get; set; }
        public virtual EventsTickets EventsTicket { get; set; }


    }
}