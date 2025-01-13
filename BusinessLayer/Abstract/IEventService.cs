using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;


namespace BusinessLayer.Abstract
{
    public interface IEventService:IGenericService<Event>

    {
      
        List<Event> GetEventsByCity(int cityId);
        public Event TGetByID(int id)
        {
            using var context = new Context();
            return context.Events.FirstOrDefault(e => e.EventId == id);
        }
        List<Event> TGetListWithArtistAndCategory();

       
        List<Event> GetEventsByCategory(int categoryId);

        
        List<Event> GetEventsByCityAndCategory(int cityId, int categoryId);
        Event TGetByIDWithArtistAndCategory(int id);


        List<Event> TGetList();
        List<Event> GetAllEvents();
        Dictionary<string, int> GetEventCountsByMonth();


    }
}
