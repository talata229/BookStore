using BS.Model;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Category
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public AuthorController()
        {
            _authorService = new AuthorService();
            _bookService = new BookService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AuthorPartial()
        {
            return PartialView(_authorService.GetAll().Take(10).ToList());
        }
        public ActionResult AuthorPartialFooter()
        {
            return PartialView(_authorService.GetAll().OrderBy(x => Guid.NewGuid()).Take(5).ToList());
        }
        public ViewResult BookBaseOnAuthor(int authorId = 0)
        {
            Author author = _authorService.Get(authorId);
            if (author == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Book> books = _bookService.GetAll().Where(x => x.AuthorId == authorId).ToList();
            if (books.Count == 0)
            {
                ViewBag.Book = "Không có sách nào do tác giả này viết";
            }
            ViewBag.AuthorName = author.Name;
            return View(books);
        }
        public ActionResult ListAllAuthor()
        {
            return PartialView(_authorService.GetAll().OrderBy(x=>x.Name).ToList());
        }
    }
}