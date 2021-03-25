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
    public class OrderDetailController : Controller
    {
        // GET: Admin/Publisher
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBookService _bookService;
        public OrderDetailController()
        {
            _orderDetailService = new OrderDetailService();
            _bookService = new BookService();
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.OrderIdSortParm = String.IsNullOrEmpty(sortOrder) ? "Order_desc" : "";
            ViewBag.BookTitleParm = sortOrder == "BookTitle" ? "BookTitle_desc" : "BookTitle";

            //All User
            ViewBag.AllBook = _bookService.GetAll();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = currentFilter;
            var orderDetails = _orderDetailService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                orderDetails = orderDetails.Where(x => x.Book.Title.ToLower().Contains(searchString.ToLower())||x.Order.User.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Order_desc":
                    orderDetails = orderDetails.OrderByDescending(x => x.OrderId).ToList();
                    break;
                case "BookTitle_desc":
                    orderDetails = orderDetails.OrderByDescending(x => x.Book.Title).ToList();
                    break;
                case "BookTitle":
                    orderDetails = orderDetails.OrderBy(x => x.Book.Title).ToList();
                    break;
                default: //Name ascending 
                    orderDetails = orderDetails.OrderBy(x => x.OrderId).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(orderDetails.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            int result = _orderDetailService.UpdateV2(orderDetail.OrderId, orderDetail.BookId,orderDetail);
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
        public ActionResult Delete(int orderId,int bookId)
        {
            int result = _orderDetailService.DeleteV2(orderId,bookId);
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