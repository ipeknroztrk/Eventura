using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfSavedCardDal : GenericRepository<SavedCard>, ISavedCardDal
    {
        public SavedCard Get(Expression<Func<SavedCard, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.SavedCards.SingleOrDefault(filter);
            }
        }
    }
}