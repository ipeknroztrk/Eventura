using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    internal class AppUserManager : IAppUserService
    {
        public AppUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
