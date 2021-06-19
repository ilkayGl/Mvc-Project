using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        MvcKampContext c = new MvcKampContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }


        public void Delete(T p)
        {
            var deleteentity = c.Entry(p);
            deleteentity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public List<T> FilterList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //bir dizide veya listede sadece bir tane değer göndermeye yarar singleordefauld

        }

        public void Insert(T p)
        {
            var addedentity = c.Entry(p);
            addedentity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public void Update(T p)
        {
            var updateenity = c.Entry(p);
            updateenity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
