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
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;

        public BookController()
        {
            _bookService = new BookService();
            _publisherService = new PublisherService();
            _categoryService = new CategoryService();
            _authorService = new AuthorService();
        }
        // GET: Admin/Book
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.AllPublisher = _publisherService.GetAll(); ;
            ViewBag.AllCategory = _categoryService.GetAll() ;
            ViewBag.AllAuthor = _authorService.GetAll();




            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "Title_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = currentFilter;
            var books = _bookService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(x => x.Title.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Title_desc":
                    books = books.OrderByDescending(x => x.Title).ToList();
                    break;
                case "Price_desc":
                    books = books.OrderByDescending(x => x.Price).ToList();
                    break;
                case "Price":
                    books = books.OrderBy(x => x.Price).ToList();
                    break;
                default: //Name ascending 
                    books = books.OrderBy(x => x.Title).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(books.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public string ProcessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/ImagesBook/" + file.FileName));
            return file.FileName;
        }
        [HttpPost]
        public string ProcessUploadEdit(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/ImagesBook/" + file.FileName));
            return file.FileName;
        }


        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = _bookService.Insert(book);
                if (result > 0)
                {
                    return Content("successful");
                }
                else
                {
                    return Content("failed");
                }
            }
            catch (Exception ex)
            {
                return Content("Lỗi khi Create " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            int result = _bookService.Update(book.BookId, book);
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
        public ActionResult Delete(int bookId)
        {
            int result = _bookService.Delete(bookId);
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