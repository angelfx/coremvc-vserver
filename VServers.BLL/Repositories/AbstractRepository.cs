using System;
using System.Collections.Generic;
using System.Text;
using VServers.Entities;
using VServers.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace VServers.BLL.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class, new()
    {
        protected IDALContext db;
        protected AbstractRepository(IDALContext context)
        {
            db = context;
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            db.Set<T>().Update(item);
        }

        public void Delete(int id)
        {
            var item = db.Set<T>().Find(id);
            if (item != null)
                db.Set<T>().Remove(item);
        }
    }
}
