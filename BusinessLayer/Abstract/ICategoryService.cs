using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        
        List<Category> GetCategories();

     
        List<string> GetCategoryNames();

        List<Category> GetAll();
        Category TGetByID(List<int> categoryIds);
    }
}
