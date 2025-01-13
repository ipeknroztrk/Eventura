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
    public class EfArtistDal : GenericRepository<Artist>, IArtistDal
    {
        private readonly Context _context;

        public EfArtistDal(Context context)
        {
            _context = context;
        }

        public List<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        public Artist TGetByID(List<int> artistIds)
        {
            throw new NotImplementedException();
        }

    }
}
