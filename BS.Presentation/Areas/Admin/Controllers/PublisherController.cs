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
    public class PublisherController : Controller
    {
        // GET: Admin/Publisher
        private readonly IPublisherService _publisherService;
        public PublisherController()
        {
            _publisherService = new PublisherService();
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.AddressParm = sortOrder == "Address" ? "Address_desc" : "Address";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = currentFilter;
            var publishers = _publisherService.GetAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                publishers = publishers.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    publishers = publishers.OrderByDescending(x => x.Name).ToList();
                    break;
                case "Address_desc":
                    publishers = publishers.OrderByDescending(x => x.Address).ToList();
                    break;
                case "Address":
                    publishers = publishers.OrderBy(x => x.Address).ToList();
                    break;
                default: //Name ascending 
                    publishers = publishers.OrderBy(x => x.Name).ToList();
                    break;
            }
            int pageSize = 5;
            int pageNumber = page ?? 1;
            return View(publishers.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        public ActionResult Create(Publisher publisher)
        {
            try
            {
                int result = _publisherService.Insert(publisher);
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
        public ActionResult Edit(Publisher publisher)
        {
            int result = _publisherService.Update(publisher.PublisherId, publisher);
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
        public ActionResult Delete(int publisherId)
        {
            int result = _publisherService.Delete(publisherId);
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