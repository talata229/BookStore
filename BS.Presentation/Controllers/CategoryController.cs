using BS.Model;
using BS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BS.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
            _bookService = new BookService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryPartial()
        {
            return PartialView(_categoryService.GetAll().Take(10).ToList());
        }
        //var result = collection.OrderBy(t => Guid.NewGuid()).Take(10);
        public ActionResult CategoryPartialFooter()
        {
            return PartialView(_categoryService.GetAll().OrderBy(x=>Guid.NewGuid()).Take(5).ToList());
        }
        public ViewResult BookBaseOnCategory(int categoryId = 0,string searchString ="")
        {
            Category category = _categoryService.Get(categoryId);
            if (category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (searchString == "")
            {
                List<Book> books = _bookService.GetAll().Where(x => x.CategoryId == categoryId).ToList();
                if (books.Count == 0)
                {
                    ViewBag.Book = "Không có sách nào thuộc chủ đề này";
                }
                ViewBag.CategoryName = category.Name;
                return View(books);
            } else
            {
                List<Book> books = _bookService.GetAll().Where(x => x.CategoryId == categoryId && x.Title.ToLower().Contains(searchString.ToLower())).ToList();
                if (books.Count == 0)
                {
                    ViewBag.Book = "Không có sách nào thuộc với tên = "+ searchString + "thuộc chủ đề này";
                }
                ViewBag.CategoryName = category.Name;
                return View(books);
            }
           
        }


        //Category khác sẽ hiển thị bảng chứa toàn bộ category
        public ActionResult ListAllCategory()
        {
            return PartialView(_categoryService.GetAll().OrderBy(x => x.Name).ToList());
        }
    }
}