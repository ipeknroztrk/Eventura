using DataAccessLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Event
    {

        [Key]
        public int EventId { get; set; }     // Birincil anahtar
        public int CategoryId { get; set; }  // Kategori ID'si
        public int ArtistId { get; set; }    // Sanatçı ID'si
        public int? CityId { get; set; }

        public int? EventsTicketId { get; set; }

        public string Title { get; set; }    // Etkinlik adı
        public string Description { get; set; } // Etkinlik açıklaması
        public DateTime EventDate { get; set; } // Etkinlik tarihi
        public string Location { get; set; } // Etkinlik mekanı
        public string ImageUrl { get; set; } // Etkinlik görsel URL'si
        public string? LocationUrl { get; set; }
        public string? Details { get; set; }


        // İlişkiler

        public virtual Category Category { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual City City { get; set; }
        public ICollection<UserFavorite> UserFavorites { get; set; }
        public virtual ICollection<EventsTickets> EventsTickets { get; set; } // Bir etkinliğin birden fazla bileti olabilir
    }


}