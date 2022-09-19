using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libraryManagementSystem.Models.Entity;


namespace libraryManagementSystem.Controllers
{
    public class RegisterController : Controller
    {

        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();

        // GET: Register

        [HttpGet]
        public ActionResult Register()
        {
            List<SelectListItem> schools = (from i in library_DB.schools.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.school_name,
                                                Value = i.school_id.ToString()
                                            }).ToList();
            ViewBag.schools = schools;
            return View();
        }

        [HttpPost]
        public ActionResult Register(members memberParam)
        {
            var school = library_DB.schools.Where(s => s.school_id == memberParam.schools.school_id).FirstOrDefault();
            memberParam.schools = school;
            library_DB.members.Add(memberParam);
            library_DB.SaveChanges();
            return View ();
        }
    }
}