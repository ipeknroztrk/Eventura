using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal:GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetAll()
        {

            using (var c = new Context())
            {
                return c.Categories.ToList();
            }

        }

        public List<string> GetCategoryNames()
        {
            using (var context = new Context())
            {
                return context.Categories.Select(c => c.Name).ToList();
            }
        }
    }
}
