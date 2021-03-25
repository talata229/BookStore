using BS.Model;
using BS.Presentation.Models;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public CartController()
        {
            _bookService = new BookService();
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
        }
        //Lấy giỏ hàng
        public List<Cart> GetCart()
        {
            List<Cart> listCart = Session["Cart"] as List<Cart>;
            if (listCart == null)
            {
                listCart = new List<Cart>();
                Session["Cart"] = listCart;
            }
            return listCart;
        }

        //Thêm sách vào giỏ hàng
        public ActionResult AddToCart(int bookId, string url)
        {
            Book book = _bookService.Get(bookId);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> listCart = GetCart();
            Cart cart = listCart.Find(x => x.BookId == bookId);
            if (cart == null)
            {
                cart = new Cart(bookId);
                listCart.Add(cart);
            }
            else
            {
                cart.Quantity++;
            }
            return Redirect(url);
        }
        //Cập nhật giỏ hàng
        public ActionResult UpdateCart(int bookId, FormCollection f)
        {
            Book book = _bookService.Get(bookId);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<Cart> listCart = GetCart();
            Cart cart = listCart.Find(x => x.BookId == bookId);
            if (cart != null)
            {
                cart.Quantity = int.Parse(f["txtQuantity"].ToString());
            }
            return RedirectToAction("EditCart");
        }

        public ActionResult DeleteCart(int bookId)
        {
            Book book = _bookService.Get(bookId);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<Cart> listCart = GetCart();
            Cart cart = listCart.Find(x => x.BookId == bookId);
            if (cart != null)
            {
                listCart.RemoveAll(x => x.BookId == bookId);
            }
            if (listCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("UpdateCart");
        }

        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> listCart = GetCart();
            return View(listCart);
        }

        //Tính tổng số lượng
        private int TotalQuantity()
        {
            int count = 0;
            List<Cart> listCart = Session["cart"] as List<Cart>;
            if (listCart != null)
            {
                count = listCart.Sum(n => n.Quantity);
            }
            return count;
        }

        private double TotalAmount()
        {
            double amount = 0;
            List<Cart> listCart = Session["cart"] as List<Cart>;
            if (listCart != null)
            {
                amount = listCart.Sum(n => n.TotalAmount);
            }
            return amount;
        }

        //Tạo partial cart
        public ActionResult CartPartial()
        {
            if (TotalQuantity() == 0)
            {
                return PartialView();
            }
            TempData["TotalQuantity"] = TotalQuantity();
            TempData["TotalAmount"] = TotalAmount();
            //ViewBag.TotalQuantity = TotalQuantity();
            //ViewBag.TotalAmount = TotalAmount();
            return PartialView();
        }

        public ActionResult EditCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> listCart = GetCart();
            return View(listCart);
        }

        public ActionResult MakeOrder()
        {
            //Kiểm tra đăng nhập
            if (Session["User"] == null)
            {
                TempData["ThongBaoDangChuaDangNhap"] = "Bạn phải đăng nhập trước khi đặt hàng";
                return RedirectToAction("Login", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["Cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }


            Order order = new Order();
            User user = Session["User"] as User;
            List<Cart> listCart = GetCart();
            order.UserId = user.UserId;
            order.DateOfOrder = DateTime.Now;

            _orderService.Insert(order);
            foreach (var item in listCart)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = order.OrderId;
                orderDetail.BookId = item.BookId;
                orderDetail.Quantity = item.Quantity;
                _orderDetailService.Insert(orderDetail);
            }
            TempData["MakeOrder"] = listCart;
            //Reset lại Session["Cart"] 
            Session.Remove("Cart");
            return RedirectToAction("MakeOrderSuccess", "Home");
        }
    }
}