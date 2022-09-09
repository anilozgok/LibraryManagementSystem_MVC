using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace libraryManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
    }
}