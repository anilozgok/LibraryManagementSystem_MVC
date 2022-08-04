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
    public class SchoolController : Controller
    {
        DB_LIBRARYEntities library_DB=new DB_LIBRARYEntities();

        // GET: school
        public ActionResult Index(string searchSchool, int page=1)
        {
            //var schoolList= library_DB.schools.ToList();
            //return View(schoolList);
            var school = from s in library_DB.schools select s;
            if (!string.IsNullOrEmpty(searchSchool))
                school = school.Where(s => s.school_name.Contains(searchSchool));
            return View(school.ToList().ToPagedList(page, 15));
        }

        [HttpGet]
        public ActionResult addSchool()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addSchool(schools schoolParam)
        {
            if (ModelState.IsValid)
            {
                library_DB.schools.Add(schoolParam);
                library_DB.SaveChanges();
                return View();
            }
            else
            {
                return View("addSchool");
            }
        }

        public ActionResult deleteSchool(int id)
        {
            var delschl=library_DB.schools.Find(id);
            library_DB.schools.Remove(delschl);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult showUpdateSchool(int id)
        {
            var school = library_DB.schools.Find(id);
            return View("showUpdateSchool", school);
        }

        public ActionResult updateSchool(schools updateSchool)
        {
            if (ModelState.IsValid)
            {
                var school = library_DB.schools.Find(updateSchool.school_id);
                school.school_name = updateSchool.school_name;
                library_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("showUpdateSchool");
            }
        }


    }
}