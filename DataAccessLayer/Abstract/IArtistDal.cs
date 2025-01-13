using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IArtistDal:IGenericDal<Artist>
    {
        Artist GetByID(int id);

        List<Artist> GetAll();

    }
}
