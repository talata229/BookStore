using BS.Model;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IBookService _bookService;
        public PublisherController()
        {
            _publisherService = new PublisherService();
            _bookService = new BookService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PublisherPartial()
        {
            return PartialView(_publisherService.GetAll().Take(10).ToList());
        }
        public ActionResult PublisherPartialFooter()
        {
            return PartialView(_publisherService.GetAll().OrderBy(x => Guid.NewGuid()).Take(5).ToList());
        }
        public ViewResult BookBaseOnPublisher(int publisherId = 0)
        {
            Publisher publisher = _publisherService.Get(publisherId);
            if (publisher == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Book> books = _bookService.GetAll().Where(x => x.PublisherId == publisherId).ToList();
            if (books.Count == 0)
            {
                ViewBag.Book = "Không có sách nào thuộc nhà xuất bản này";
            }
            ViewBag.PublisherName = publisher.Name;
            return View(books);
        }


        public ActionResult ListAllPublisher()
        {
            return PartialView(_publisherService.GetAll().OrderBy(x => x.Name).ToList());
        }
    }
}