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
    public class AuthorController : Controller
    {
        // GET: Admin/Author
        private readonly AuthorService _authorService;
        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "BirthDate" ? "BirthDate_desc" : "BirthDate";
            ViewBag.AddressParm = sortOrder == "Address" ? "Address_desc" : "Address";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var authors = _authorService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(a => a.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    authors = authors.OrderByDescending(s => s.Name).ToList();
                    break;
                case "BirthDate":
                    authors = authors.OrderBy(s => s.BirthDate).ToList();
                    break;
                case "BirthDate_desc":
                    authors = authors.OrderByDescending(s => s.BirthDate).ToList();
                    break;
                case "Address":
                    authors = authors.OrderBy(s => s.Address).ToList();
                    break;
                case "Address_desc":
                    authors = authors.OrderByDescending(s => s.Address).ToList();
                    break;
                default:  // Name ascending 
                    authors = authors.OrderBy(s => s.Name).ToList();
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                int result = _authorService.Insert(author);
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
        public ActionResult Edit(Author author)
        {
            int result = _authorService.Update(author.AuthorId, author);
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
        public ActionResult Delete(int authorId)
        {
            int result = _authorService.Delete(authorId);
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