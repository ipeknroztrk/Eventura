using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  
        public class Artist
        {
            public int ArtistId { get; set; }    // Birincil anahtar
            public string Name { get; set; }      // Sanatçı adı
            public string Bio { get; set; }       // Sanatçı biyografisi
            public string ImageUrl { get; set; }  // Sanatçı görsel URL'si

            // İlişkiler
            public virtual ICollection<Event> Events { get; set; }
        }
    

}
