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
    public class TransactionController : Controller
    {

        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();
        // GET: Transaction
        public ActionResult Index(string searchTransaction, int page=1)
        {
            var completedTransaction = from t in library_DB.transactions select t;
            completedTransaction = completedTransaction.Where(t => t.transaction_status == true);
            if (!string.IsNullOrEmpty(searchTransaction))
                completedTransaction = completedTransaction.Where(t => (t.members.member_name + " " + t.members.member_surname).Contains(searchTransaction));
            return View(completedTransaction.ToList().ToPagedList(page, 15));
        }
    }
}