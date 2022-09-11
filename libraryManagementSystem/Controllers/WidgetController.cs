using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libraryManagementSystem.Models.Entity;

namespace libraryManagementSystem.Controllers
{
    public class WidgetController : Controller
    {

        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();

        // GET: Wiget
        public ActionResult Index()
        {
            //linq query for number of books
            var books = from b in library_DB.books select b;
            int number_of_books = books.Count();
            ViewBag.number_of_books = number_of_books;

            //linq query for nubmer of member
            var members = from m in library_DB.members select m;
            int number_of_member = members.Count();
            ViewBag.number_of_member = number_of_member;

            //linq query for total money in th safe
            var safe = from s in library_DB.safe select s;
            var total_money = safe.Sum(s => s.total);

            return View();
        }
    }
}