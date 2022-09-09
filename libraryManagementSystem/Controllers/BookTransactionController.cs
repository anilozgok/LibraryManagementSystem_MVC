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
    public class BookTransactionController : Controller
    {
        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();

        // GET: BookTransaction
        public ActionResult Index(string searchTransaction, int page = 1)
        {
            var trns = from t in library_DB.transactions select t ;
            trns = trns.Where(t => t.transaction_status == false);
            if (!string.IsNullOrEmpty(searchTransaction))
                trns = trns.Where(t => (t.members.member_name + " " + t.members.member_surname).Contains(searchTransaction));

            return View(trns.ToList().ToPagedList(page, 15));
        }

        [HttpGet]
        public ActionResult lendBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult lendBook(transactions trnasactionParam)
        {
            library_DB.transactions.Add(trnasactionParam);
            library_DB.SaveChanges();
            return View();
        }

        public ActionResult returnBook(int id)
        {
            var trns = library_DB.transactions.Find(id);
            trns.member_return_date = DateTime.Parse(DateTime.Now.ToShortDateString());
            trns.transaction_status = true;
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}