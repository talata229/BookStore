using BS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Service
{
    public class Service<T> : IService<T> where T : class
    {
        protected Repository<T> repository;

        public Service()
        {
            repository = new Repository<T>();
        }

        public int Delete(object objectKey)
        {
            repository.Delete(objectKey);
            return repository.SaveChanges();
        }
        public int DeleteV2(object objectKey1,object objectKey2)
        {
            repository.DeleteV2(objectKey1, objectKey2);
            return repository.SaveChanges();
        }

        public T Get(object objectKey)
        {
            return repository.Get(objectKey);
        }

        public ICollection<T> GetAll()
        {
            return repository.GetAll();
        }

        public int Insert(T objectT)
        {
            repository.Insert(objectT);
            return repository.SaveChanges();
        }

        public int Update(object objectKey, T objectT)
        {
            repository.Update(objectKey, objectT);
            return repository.SaveChanges();
        }
        public int UpdateV2(object objectKey1, object objectKey2, T objectT)
        {
            repository.UpdateV2(objectKey1, objectKey2, objectT);
            return repository.SaveChanges();
        }
    }
}
