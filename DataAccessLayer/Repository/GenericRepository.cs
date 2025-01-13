using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public void TAdd(T entity)
        {
            using var c = new Context();
            c.Set<T>().Add(entity); // Veya Entity Framework'deki uygun DbSet ile ekleyin.
            c.SaveChanges();
        }


        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }
        public List<T> GetList(Func<T, bool> filter)
        {
            using (var context = new Context())
            {
                return context.Set<T>().Where(filter).ToList();
            }
        }



        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public List<T> GetTicketsWithEvents()
        {
            throw new NotImplementedException();
        }
        public void Insert(T t)
        {
            using var c = new Context();

            if (t is Event eventObj)
            {
                if (eventObj.EventDate.Kind == DateTimeKind.Unspecified)
                {
                    eventObj.EventDate = eventObj.EventDate.ToUniversalTime(); // UTC'ye dönüştür
                }
            }

            c.Add(t);
            c.SaveChanges();
        }


        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using var c = new Context();
            return filter == null ? c.Set<T>().ToList() : c.Set<T>().Where(filter).ToList();
        }
        public void Add(T entity)
        {
            using var c = new Context();
            c.Set<T>().Add(entity);
            c.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            using var c = new Context();
            c.Set<T>().AddRange(entities);
            c.SaveChanges();
        }





    }
}