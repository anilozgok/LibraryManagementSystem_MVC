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
            ViewBag.total_money = total_money;

            //linq query for books on lend
            var transactions = from t in library_DB.transactions select t;
            var number_of_lend = transactions.Count(t => t.transaction_status == false);
            ViewBag.number_of_lend = number_of_lend;

            //linq query for number of category
            var category = from c in library_DB.category select c;
            var number_of_category = category.Count();
            ViewBag.number_of_category = number_of_category;

            //linq query for most active member
                                              //store procedure
            var most_active_member = library_DB.MostActiveMember().FirstOrDefault();
            ViewBag.most_active_member = most_active_member;

            //linq querry for most read books
                                          //store procedure
            var most_read_book = library_DB.MostReadBook().FirstOrDefault();
            ViewBag.most_read_book = most_read_book;

            //linq query for author with most books
                                              //store procedure
            var most_book_author = library_DB.MostBookAuthor().FirstOrDefault();
            ViewBag.most_book_author = most_book_author;



            return View();
        }
    }
}