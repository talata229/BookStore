using BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public int Login(string userName, string password)
        {
            User user = db.Users.FirstOrDefault(x => x.UserName == userName);
            if (user.Role == 1) return 2;//Tài khoản là admin
            if (user == null)
            {
                return 0; //Không tồn tại user
            }
            else
            {
                if (user.IsActive == false)
                {
                    return -1; //Tài khoản đang bị khóa , không active
                }
                else
                {
                    if (user.Password == password)
                    {
                        return 1; //đăng nhập thành công là user bình thường
                    }
                    else
                    {
                        return -2; //Sai password
                    }
                }
            }
        }

        public int Register(User user)
        {
            User tempUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (tempUser == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return 1;//Đăng ký thành công
            }
            else
            {
                return 0; //Đăng ký thất bại
            }
        }

        public User SearchUserWithUserName(string userName)
        {
            User user = db.Users.Where(x => x.UserName == userName).FirstOrDefault();
            return user;
        }
    }
}
