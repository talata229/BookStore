using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Service
{
    public interface IService<T>
    {
        ICollection<T> GetAll();
        T Get(object objectKey);
        int Insert(T objectT);
        int Update(object objectKey, T objectT);
        int UpdateV2(object objectKey1, object objectKey2, T objectT);
        int Delete(object objectKey);
        int DeleteV2(object objectKey1, object objectKey2);
    }
}
