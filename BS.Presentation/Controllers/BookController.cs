using BS.Model;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        //public ActionResult GetRandomBook()
        //{
        //    Random rd = new Random();
        //    int bookIdRamdom = rd.Next(1, _bookService.GetAll().Count+1);
        //    Book book = _bookService.Get(bookIdRamdom);
        //    return PartialView(book);
        //}
        public ActionResult GetRandomBook()
        {
            return PartialView(_bookService.GetAll().OrderBy(x=>Guid.NewGuid()).Take(10).ToList());
        }


        public ActionResult DetailBook(int bookId)
        {

            Book book = _bookService.Get(bookId);

                return View(book);
        }
    }
}