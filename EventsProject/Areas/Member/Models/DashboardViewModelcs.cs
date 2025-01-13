using EntityLayer.Concrete;
namespace EventsProject.Areas.Member.Models


{
    public class DashboardViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Image { get; set; } // Profil fotoğrafı

        public List<Event> FavoriteEvents { get; set; }
    }
}

