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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = currentFilter;
            var categories = _categoryService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    categories = categories.OrderByDescending(x => x.Name).ToList();
                    break;
                default: //Name ascending 
                    categories = categories.OrderBy(x => x.Name).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(categories.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = _categoryService.Insert(category);
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
        public ActionResult Edit(Category category)
        {
            int result = _categoryService.Update(category.CategoryId, category);
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
        public ActionResult Delete(int categoryId)
        {
            int result = _categoryService.Delete(categoryId);
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
