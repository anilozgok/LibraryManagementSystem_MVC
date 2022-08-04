using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libraryManagementSystem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace libraryManagementSystem.Controllers
{
    public class PublisherController : Controller
    {

        DB_LIBRARYEntities library_DB=new DB_LIBRARYEntities();

        // GET: Publisher
        public ActionResult Index(string searchPublisher, int page=1)
        {
            //var publishers = library_DB.publishers.ToList();
            //return View(publishers);
            var publisher = from p in library_DB.publishers select p;
            if (!string.IsNullOrEmpty(searchPublisher))
                publisher = publisher.Where(p => p.publisher_name.Contains(searchPublisher));
            return View(publisher.ToList().ToPagedList(page, 15));

        }

        [HttpGet]
        public ActionResult addPublisher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addPublisher(publishers publisherParam)
        {
            if (ModelState.IsValid)
            {
                library_DB.publishers.Add(publisherParam);
                library_DB.SaveChanges();
                return View();
            }
            else
            {
                return View("addPublisher");
            }
        }

        public ActionResult deletePublisher(int id)
        {
            var delPub=library_DB.publishers.Find(id);
            library_DB.publishers.Remove(delPub);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult showUpdatePublisher(int id)
        {
            var updPub = library_DB.publishers.Find(id);
            return View("showUpdatePublisher", updPub);
        }

        public ActionResult updatePublisher(publishers updatePublisher)
        {
            if (ModelState.IsValid)
            {
                var pub = library_DB.publishers.Find(updatePublisher.publisher_id);
                pub.publisher_name = updatePublisher.publisher_name;
                library_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("showUpdatePublisher");
            }
        }

    }
}