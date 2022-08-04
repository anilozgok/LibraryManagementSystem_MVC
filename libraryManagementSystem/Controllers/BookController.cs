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
    public class BookController : Controller
    {
        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();
        // GET: Book
        public ActionResult Index(string searchBook,int page=1)
        {
            //var book = library_DB.books.ToList();
            //return View(book);
            var book = from b in library_DB.books select b;
            if (!string.IsNullOrEmpty(searchBook))
                book = book.Where(b => b.book_name.Contains(searchBook));
            return View(book.ToList().ToPagedList(page,15));
        }

        [HttpGet]
        public ActionResult addBook()
        {
            //preparing category names for dropdown list
            List<SelectListItem> category = (from i in library_DB.category.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.category_name,
                                                 Value = i.category_id.ToString()
                                             }).ToList();
            ViewBag.ctgry = category;

            //preparing author name and surname for dropdown list
            List<SelectListItem> author = (from i in library_DB.author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.author_name + " " + i.author_surname,
                                               Value = i.author_id.ToString()
                                           }).ToList();
            ViewBag.athr = author;

            //preparing publishers for dropdown list
            List<SelectListItem> publisher = (from i in library_DB.publishers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.publisher_name,
                                                  Value = i.publisher_id.ToString()
                                              }).ToList();
            ViewBag.pblshr = publisher;


            return View();
        }

        [HttpPost]
        public ActionResult addBook(books bookParam)
        {

            //finding selected category id and updating book's category field
            var ctg = library_DB.category.Where(k => k.category_id == bookParam.category1.category_id).FirstOrDefault();
            //finding selected author id and updating book's category field
            var aut = library_DB.author.Where(k => k.author_id == bookParam.author1.author_id).FirstOrDefault();
            //finding selected publisher id and updating book's category field
            var pub = library_DB.publishers.Where(k => k.publisher_id == bookParam.publishers.publisher_id).FirstOrDefault();
            bookParam.category1 = ctg;
            bookParam.author1 = aut;
            bookParam.publishers = pub;
            bookParam.status = true;
            library_DB.books.Add(bookParam);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult deleteBook(int id)
        {
            var delBook = library_DB.books.Find(id);
            library_DB.books.Remove(delBook);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult showUpdateBook(int id)
        {
            var updBook = library_DB.books.Find(id);

            //preparing category names for dropdpwn list
            List<SelectListItem> category = (from i in library_DB.category.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.category_name,
                                                 Value = i.category_id.ToString()
                                             }).ToList();
            ViewBag.ctgry = category;

            //preparing author name and surname for dropdpwn list
            List<SelectListItem> author = (from i in library_DB.author.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.author_name + " " + i.author_surname,
                                               Value = i.author_id.ToString()
                                           }).ToList();
            ViewBag.athr = author;

            //preparing publishers for dropdpwn list
            List<SelectListItem> publisher = (from i in library_DB.publishers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.publisher_name,
                                                  Value = i.publisher_id.ToString()
                                              }).ToList();
            ViewBag.pblshr = publisher;

            return View("showUpdateBook", updBook);
        }

        public ActionResult updateBook(books bookParam)
        {
            //if (bookParam.status == null)
            //    bookParam.status = true;
            var book = library_DB.books.Find(bookParam.book_id);
            book.book_name = bookParam.book_name;
            //finding selected category id and updating book's category field
            book.category = library_DB.category.Where(k => k.category_id == bookParam.category1.category_id).FirstOrDefault().category_id;
            //finding selected author id and updating book's category field
            book.author = library_DB.author.Where(k => k.author_id == bookParam.author1.author_id).FirstOrDefault().author_id;
            //finding selected publisher id and updating book's category field
            book.publisher = library_DB.publishers.Where(k => k.publisher_id == bookParam.publishers.publisher_id).FirstOrDefault().publisher_id;
            book.publishing_year = bookParam.publishing_year;
            book.page_number = bookParam.page_number;
            //book.status = bookParam.status; we are not updating status field
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}