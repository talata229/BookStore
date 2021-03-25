using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Repository
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
        T Get(object objectKey);
        void Insert(T objectT);
        void Update(object objectKey, T objectT);
        void UpdateV2(object objectKey1, object objectKey2, T objectT);

        void Delete(object objectKey);
        void DeleteV2(object objectKey1, object objectKey2);
        int SaveChanges();
    }
}
