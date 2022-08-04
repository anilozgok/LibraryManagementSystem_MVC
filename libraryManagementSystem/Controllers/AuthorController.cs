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
    public class AuthorController : Controller
    {

        DB_LIBRARYEntities library_DB=new DB_LIBRARYEntities();

        // GET: Author
        public ActionResult Index(string searchAuthor, int page=1)
        {
            //var authorList = library_DB.author.ToList().ToPagedList(page,15);
            //return View(authorList);
            var author = from a in library_DB.author select a;
            if (!string.IsNullOrEmpty(searchAuthor))
                author = author.Where(a => (a.author_name + " " + a.author_surname).Contains(searchAuthor));
            return View(author.ToList().ToPagedList(page, 15));
        }

        [HttpGet]
        public ActionResult addAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addAuthor(author authorParam)
        {
            if (ModelState.IsValid)
            {
                library_DB.author.Add(authorParam);
                library_DB.SaveChanges();
                return View();
            }
            else
            {
                return View("addAuthor");
            }
        }

        public ActionResult deleteAuthor(int id)
        {
            var delAut=library_DB.author.Find(id);
            library_DB.author.Remove(delAut);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult showUpdateAuthor(int id)
        {
            var updAut=library_DB.author.Find(id);
            return View("showUpdateAuthor",updAut);
        }

        public ActionResult updateAuthor(author updateAuthor)
        {
            if (ModelState.IsValid)
            {
                var updAut = library_DB.author.Find(updateAuthor.author_id);
                updAut.author_name = updateAuthor.author_name;
                updAut.author_surname = updateAuthor.author_surname;
                library_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("showUpdateAuthor");
            }

        }

    }
}