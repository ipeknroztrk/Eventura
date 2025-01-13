using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ArtistManager : IArtistService
    {
        private readonly IArtistDal _artistDal;

        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
        }

        public List<Artist> GetAll()
        {
            return _artistDal.GetAll();
        }




        public void TAdd(Artist artist)
        {

           
            _artistDal.Insert(artist);
        }

        public void TDelete(Artist artist)
        {
            
            _artistDal.Delete(artist);
        }
        public Artist TGetByID(int id)
        {
            using (var c = new Context())
            {
                return c.Artists.FirstOrDefault(c => c.ArtistId == id);
            }
        }

        public Artist TGetByID(List<int> artistIds)
        {
            throw new NotImplementedException();
        }

        public List<Artist> TGetList()
        {
            return _artistDal.GetAll();
        }

        public void TUpdate(Artist artist)
        {
            
            _artistDal.Update(artist);
        }
    }
}