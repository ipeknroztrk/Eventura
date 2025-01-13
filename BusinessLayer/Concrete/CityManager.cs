// CityManager.cs
using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CityManager : ICityService, IGenericService<City>  
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        // Şehirleri al
        public List<City> GetCities()
        {
            return _cityDal.GetAllCities();
        }

        public List<string> GetCityNames()
        {
           
            return _cityDal.GetList().Select(c => c.CityName).ToList();
        }

       
        public void TAdd(City city)
        {
            _cityDal.Insert(city);  
        }

       
        public void TDelete(City city)
        {
            _cityDal.Delete(city); 
        }

       
        public void TUpdate(City city)
        {
            _cityDal.Update(city); 
        }

      
        public List<City> TGetList()
        {
            return _cityDal.GetList(); 
        }

       
        public City TGetByID(int id)
        {
            return _cityDal.GetByID(id);  
        }
    }
}
