using BS.Model;
using BS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Service
{
    public class UserService : Service<User>, IUserService
    {
        private IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public int Login(string userName, string password)
        {
            return userRepository.Login(userName, password);
        }

        public int Register(User user)
        {
            return userRepository.Register(user);
        }

        public User SearchUserWithUserName(string userName)
        {
            return userRepository.SearchUserWithUserName(userName);
        }
    }
}
