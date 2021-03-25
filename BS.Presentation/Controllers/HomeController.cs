using BS.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        public HomeController()
        {
            _bookService = new BookService();
        }

        public ActionResult Index(int? page,string searchString="", string url="")
        {
        
            if (searchString == "")
            {
                int pageNumber = (page ?? 1);
                int pageSize = 16;
                return View(_bookService.GetAll().OrderBy(x => x.Title).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.BookTitle = searchString;
                int pageNumber = (page ?? 1);
                int pageSize = 16;
                return View(_bookService.GetAll().OrderBy(n => n.Price).Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToPagedList(pageNumber, pageSize));
            }
        }


        public ActionResult MakeOrderSuccess()
        {
            return View();
        }
        public ActionResult Introduce()
        {
            return View();
        }
        
    }
}