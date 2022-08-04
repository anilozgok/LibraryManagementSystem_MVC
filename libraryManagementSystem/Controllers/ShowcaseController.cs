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
    public class ShowcaseController : Controller
    {

        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();
        // GET: Window
        public ActionResult Index(int page=1)
        {
            //fetch the rows that only has image_links ig image_link is null do not fetch it.
            var book = from b in library_DB.books select b;
            book = book.Where(b => b.image_link != null);
            return View(book.ToList().ToPagedList(page,9));
        }
    }
}