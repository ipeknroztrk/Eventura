using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IEventDal : IGenericDal<Event>
    {
        
        List<Event> GetEventsByCity(int cityId);

        List<Event> GetEventsByCategory(int categoryId);

        
        List<Event> GetEventsByCityAndCategory(int cityId, int categoryId);

        List<Event> TGetListWithArtistAndCategory();
        Event TGetByIDWithArtistAndCategory(int id);
    }
}
