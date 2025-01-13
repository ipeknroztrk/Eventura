using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }

        public ICollection<UserFavorite> UserFavorites { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<SavedCard> SavedCards { get; set; }

    }
}