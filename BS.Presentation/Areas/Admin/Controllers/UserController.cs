using BS.Model;
using BS.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.UserNameSortParm = String.IsNullOrEmpty(sortOrder) ? "UserName_desc" : "";
            ViewBag.FullNameParm = sortOrder == "FullName" ? "FullName_desc" : "FullName";
            ViewBag.AddressParm = sortOrder == "Address" ? "Address_desc" : "Address";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = currentFilter;
            var users = _userService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(x =>x.UserName.ToLower().Contains(searchString.ToLower())|| x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "UserName_desc":
                    users = users.OrderByDescending(x => x.UserName).ToList();
                    break;
                case "FullName_desc":
                    users = users.OrderByDescending(x => x.Name).ToList();
                    break;
                case "FullName":
                    users = users.OrderBy(x => x.Name).ToList();
                    break;
                case "Address_desc":
                    users = users.OrderByDescending(x => x.Address).ToList();
                    break;
                case "Address":
                    users = users.OrderBy(x => x.Address).ToList();
                    break;
                default: //Name ascending 
                    users = users.OrderBy(x => x.UserName).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(users.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            int result = _userService.Update(user.UserId, user);
            if (result > 0)
            {
                return Content("successful");
            }
            else
            {
                return Content("failed");
            }
        }


        [HttpPost]
        public ActionResult Delete(int userId)
        {
            int result = _userService.Delete(userId);
            if (result > 0)
            {
                return Content("successful");
            }
            else
            {
                return Content("failed");
            }
        }

    }
}