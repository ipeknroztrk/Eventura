
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfCityDal : GenericRepository<City>, ICityDal
    {
        public List<City> GetAllCities()
        {
            
            using (var context = new Context())
            {
                return context.Cities.ToList();  
            }
        }
    }
}
