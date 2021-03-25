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
    public class OrderController : Controller
    {
        // GET: Admin/Publisher
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IOrderDetailService _orderDetailService;
        public OrderController()
        {
            _orderService = new OrderService();
            _userService = new UserService();
            _orderDetailService = new OrderDetailService();
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateOfOrderSortParm = String.IsNullOrEmpty(sortOrder) ? "DateOfOrder_desc" : "";
            ViewBag.UserParm = sortOrder == "User" ? "User_desc" : "User";

            //All User
            ViewBag.AllUser = _userService.GetAll();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = currentFilter;
            var orders = _orderService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(x => x.User.UserName.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "DateOfOrder_desc":
                    orders = orders.OrderByDescending(x => x.DateOfOrder).ToList();
                    break;
                case "User_desc":
                    orders = orders.OrderByDescending(x => x.User.UserName).ToList();
                    break;
                case "User":
                    orders = orders.OrderBy(x => x.User.UserName).ToList();
                    break;
                default: //Name ascending 
                    orders = orders.OrderBy(x => x.DateOfOrder).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }


        //[HttpPost]
        //public ActionResult Create(Publisher publisher)
        //{
        //    try
        //    {
        //        int result = _publisherService.Insert(publisher);
        //        if (result > 0)
        //        {
        //            return Content("successful");
        //        }
        //        else
        //        {
        //            return Content("failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content("Lỗi khi Create " + ex.Message);
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            int result = _orderService.Update(order.OrderId, order);
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
        public ActionResult Delete(int orderId)
        {
            int result = _orderService.Delete(orderId);
            if (result > 0)
            {
                return Content("successful");
            }
            else
            {
                return Content("failed");
            }
        }

        public ActionResult LoadListOrderDetailWithOrderId(int orderId)
        {
            var orderdetails = _orderDetailService.GetAll().Where(x => x.OrderId == orderId).ToList();
            return PartialView(orderdetails);
        }

        [HttpPost]
        public ActionResult ChangeListOrderDetail(List<OrderDetail2> orderDetails)
        {
            try
            {
                return Content("Success");
            }
            catch (Exception ex)
            {
                return Content("Có lỗi xảy ra, lỗi = " + ex.Message);
            }
        }
    }
}
