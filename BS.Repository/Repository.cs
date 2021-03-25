using BS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected BookStoreContext db;
        protected DbSet<T> _dbSet;
        public Repository()
        {
            db = new BookStoreContext();
            _dbSet = db.Set<T>();
        }

        public void Delete(object objectKey)
        {
            var t = _dbSet.Find(objectKey);
            if (t != null)
            {
                _dbSet.Remove(t);
            }
            else
                throw new Exception("Object not exist");
        }
        public void DeleteV2( object objectKey1, object objectKey2)
        {
            var t = _dbSet.Find(objectKey1, objectKey2);
            if (t != null)
            {
                _dbSet.Remove(t);
            }
            else
                throw new Exception("Object not exist");
        }

        public T Get(object objectKey)
        {
            return _dbSet.Find(objectKey);
        }
        public T GetV2(object objectKey1, object objectKey2)
        {
            return _dbSet.Find(objectKey1, objectKey2);
        }

        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Insert(T objectT)
        {
            _dbSet.Add(objectT);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Update(object objectKey, T objectT)
        {
            var obj = Get(objectKey);
            if (obj != null)
            {
                db.Entry(obj).State = EntityState.Detached;
                db.Entry(objectT).State = EntityState.Modified;
            }
            else
                throw new Exception("Object not exist");

        }
        public void UpdateV2(object objectKey1, object objectKey2, T objectT)
        {
            var obj = GetV2(objectKey1, objectKey2);
            if (obj != null)
            {
                db.Entry(obj).State = EntityState.Detached;
                db.Entry(objectT).State = EntityState.Modified;
            }
            else
                throw new Exception("Object not exist");
        }
    }
}
