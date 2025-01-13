// ICityDal.cs
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface ICityDal : IGenericDal<City>
    {
        List<City> GetAllCities();  
    }
}
