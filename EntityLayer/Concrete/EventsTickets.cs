using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class EventsTickets
    {
        [Key]
        public int EventsTicketId { get; set; }

        public int EventId { get; set; }
        public int TicketCapacity { get; set; }
        public decimal Price { get; set; }

        public string Name { get; set; }

        public int SoldCount { get; set; }
        [NotMapped]
        public virtual ICollection<Event> Events { get; set; }
        [NotMapped]
        public virtual ICollection<Ticket> Tickets { get; set; }
        [NotMapped]
        public string EventTitle { get; set; } // Bu alan veritabanına yansımayacak.


    }



}
