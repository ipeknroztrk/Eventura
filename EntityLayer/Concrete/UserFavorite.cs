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
    public class UserFavorite
    {
        public int UserFavoriteId { get; set; } // Birincil anahtar
        public int UserId { get; set; }       // Kullanıcı ID'si (Identity User ile ilişkilendirilecek)
        public int EventId { get; set; }       // Bilet ID'si (Favori olarak eklenen bilet)

        // İlişkiler
        public virtual AppUser User { get; set; }
        public virtual Event Event { get; set; }
    }
}