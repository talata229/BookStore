using BS.Model;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                int result = _userService.Register(user);
                if (result == 0)
                {
                    ViewBag.MessageRegister = "Tài khoản đã tồn tại";
                }
                else
                {
                    ViewBag.MessageRegister = "Đăng ký thành công tài khoản "+user.UserName;
                }
            }
            else
            {
                ViewBag.MessageRegister = "Có lỗi xảy ra. Vui lòng thử lại!";
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                int result = _userService.Login(user.UserName, user.Password);
                if (result == 2)
                {
                    User tempUser = _userService.SearchUserWithUserName(user.UserName);
                    ViewBag.MessageLogin = "Đăng nhập tài khoản admin";
                    Session["User"] = tempUser;
                    return RedirectToAction("Index", "Home",new { Area = "Admin" });
                }
                else if (result == 1)
                {
                    User tempUser = _userService.SearchUserWithUserName(user.UserName);
                    ViewBag.MessageLogin = "Đăng nhập thành công";
                    Session["User"] = tempUser;
                    if (Session["Cart"] != null)
                    {
                      return  RedirectToAction("Cart", "Cart");
                    } else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else if (result == 0)
                {
                    ViewBag.MessageLogin = "Tài khoản không tồn tại";
                }
                else if (result == -1)
                {
                    ViewBag.MessageLogin = "Tài khoản đang bị khóa";
                }
                else
                {
                    ViewBag.MessageLogin = "Mật khẩu sai";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.MessageLogin = "Có lỗi xảy ra. Không đăng nhập thành công";
                return View();
            }
            
    }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
}
}

