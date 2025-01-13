using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArtistService:IGenericService<Artist>
    {
        List<Artist> GetAll();

        Artist TGetByID(List<int> artistIds);
    }
}
