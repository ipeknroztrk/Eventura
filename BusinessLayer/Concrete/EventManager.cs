using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void TAdd(Event t)
        {
            
            if (!string.IsNullOrEmpty(t.Title) && t.CategoryId != 0 && t.ArtistId != 0)
            {
                _eventDal.Insert(t); 
            }
            else
            {
                
                throw new Exception("Başlık, kategori ve sanatçı bilgileri gerekli!");
            }
        }
        public List<Event> TGetList()
        {
            return _eventDal.GetList();
        }

        
        public Event TGetByID(int id)
        {
            return _eventDal.GetByID(id);
        }
        public void TDelete(Event t)
        {
            _eventDal.Delete(t);
        }

    
        public void TUpdate(Event eventObj)
        {
            using (var context = new Context())
            {
                context.Events.Update(eventObj);
                context.SaveChanges();
            }
        }
        public List<Event> TGetListWithArtistAndCategory()
        {
            return _eventDal.TGetListWithArtistAndCategory();
        }

        public Event TGetByIDWithArtistAndCategory(int id)
        {
            return _eventDal.TGetByIDWithArtistAndCategory(id);
        }



        public List<Event> GetAllEvents()
        {
            return _eventDal.GetList();
        }
        public List<string> GetEventTitles()
        {
            using var context = new Context();
            return context.Events.Select(e => e.Title).ToList();
        }



        public List<Event> GetEventsByCity(int cityId) => _eventDal.GetEventsByCity(cityId);
        public List<Event> GetEventsByCategory(int categoryId) => _eventDal.GetEventsByCategory(categoryId);
        public List<Event> GetEventsByCityAndCategory(int cityId, int categoryId) => _eventDal.GetEventsByCityAndCategory(cityId, categoryId);

        public Dictionary<int, int> GetEventCountsByMonth()
        {
            using var context = new Context();
            return context.Events
                .GroupBy(e => e.EventDate.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .ToDictionary(x => x.Month, x => x.Count);
        }

        Dictionary<string, int> IEventService.GetEventCountsByMonth()
        {
            throw new NotImplementedException();
        }
    }
}
