using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfEventDal : GenericRepository<Event>, IEventDal
    {
        
        public List<Event> GetEventsByCity(int cityId)
        {
            using var context = new Context();
      
            return context.Events.Where(e => e.CityId == cityId).ToList();
        }

  
        public List<Event> GetEventsByCategory(int categoryId)
        {
            using var context = new Context();
         
            return context.Events.Where(e => e.CategoryId == categoryId).ToList();
        }

        public List<Event> GetEventsByCityAndCategory(int cityId, int categoryId)
        {
            using var context = new Context();
            // Hem cityId hem de categoryId'yi kullanarak sorgulama yapıyoruz
            return context.Events.Where(e => e.CityId == cityId && e.CategoryId == categoryId).ToList();
        }

        public List<Event> TGetListWithArtistAndCategory()
        {
            using (var c = new Context())
            {
                return c.Set<Event>()
                        .Include(e => e.Category) // Category ilişkisini dahil ediyoruz
                        .Include(e => e.Artist)   // Artist ilişkisini dahil ediyoruz
                        .ToList();
            }
        }
        public Event TGetByIDWithArtistAndCategory(int id)
        {
            using (var c = new Context()) // using var doğru şekilde kapatılmış
            {
                return c.Events
                        .Include(e => e.Artist)    // Artist ilişkisini ilişkilendiriyoruz
                        .Include(e => e.Category)  // Category ilişkisini ilişkilendiriyoruz
                        .FirstOrDefault(e => e.EventId == id);
            }
        }
        public List<Event> GetAllEvents()
        {
            using var context = new Context();
            return context.Events.ToList(); // Bütün etkinlikleri getirir
        }

        public Event TGetByID(int id)
        {
            using var context = new Context();
            return context.Events.FirstOrDefault(e => e.EventId == id);
        }
    }
}
