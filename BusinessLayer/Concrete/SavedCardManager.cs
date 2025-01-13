using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SavedCardManager : IGenericService<SavedCard>, ISavedCardService
    {
        private readonly ISavedCardDal _savedCardDal;

        public SavedCardManager(ISavedCardDal savedCardDal)
        {
            _savedCardDal = savedCardDal;
        }

        public SavedCard Get(Expression<Func<SavedCard, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public void TAdd(SavedCard t)
        {
            _savedCardDal.Insert(t); // Save işlemi burada yapılır
        }

        public void TDelete(SavedCard t)
        {
            _savedCardDal.Delete(t);
        }


        public SavedCard TGetByID(int id)
        {
            // Burada Get metodunu kullanarak kartı ID'ye göre getiriyoruz
            return _savedCardDal.Get(x => x.SavedCardId == id);
        }

        public List<SavedCard> TGetList()
        {
            return _savedCardDal.GetList();
        }

        public void TUpdate(SavedCard t)
        {
            _savedCardDal.Update(t);
        }
    }
}