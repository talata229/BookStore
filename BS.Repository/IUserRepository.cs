using BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        int Login(string userName, string password);
        int Register(User user);

        User SearchUserWithUserName(string userName);
    }
}
