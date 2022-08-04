using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using libraryManagementSystem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace libraryManagementSystem.Controllers
{
    public class MemberController : Controller
    {


        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();

        // GET: Member
        public ActionResult Index(string searchMember, int page = 1)
        {
            var member = from m in library_DB.members select m;
            if (!string.IsNullOrEmpty(searchMember))
                member = member.Where(m => (m.member_name + " " + m.member_surname).Contains(searchMember));
            return View(member.ToList().ToPagedList(page, 15));
        }

        public ActionResult deleteMember(int id)
        {
            var delMember = library_DB.members.Find(id);
            library_DB.members.Remove(delMember);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult addMember()
        {
            List<SelectListItem> schools = (from i in library_DB.schools.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.school_name,
                                                Value = i.school_id.ToString()
                                            }).ToList();
            ViewBag.schl = schools;
            return View();
        }

        [HttpPost]
        public ActionResult addMember(members memberParam)
        {
            var school = library_DB.schools.Where(s => s.school_id == memberParam.schools.school_id).FirstOrDefault();
            memberParam.schools = school;
            library_DB.members.Add(memberParam);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult showUpdateMember(int id)
        {
            var updMember = library_DB.members.Find(id);
            List<SelectListItem> schools = (from i in library_DB.schools.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.school_name,
                                                Value = i.school_id.ToString()
                                            }).ToList();
            ViewBag.schl = schools;
            return View("showUpdateMember", updMember);
        }

        public ActionResult updateMember(members memberParam)
        {
            var updMem = library_DB.members.Find(memberParam.member_id);
            updMem.member_name = memberParam.member_name;
            updMem.member_surname = memberParam.member_surname;
            updMem.mail = memberParam.mail;
            updMem.user_name = memberParam.user_name;
            updMem.phone_number = memberParam.phone_number;
            updMem.school = library_DB.schools.Where(s => s.school_id == memberParam.schools.school_id).FirstOrDefault().school_id;
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult showChangePassword(int id)
        {
            var member = library_DB.members.Find(id);
            return View("showChangePassword", member);
        }

        public ActionResult changePassword(members memberParam, string newPassword, string newPassword2)
        {

            if (!string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(newPassword2) && newPassword == newPassword2)
            {
                var member = library_DB.members.Find(memberParam.member_id);
                member.password = newPassword;
                library_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Passwords do not match";
                return View("showChangePassword");
            }
                
        }

    }
}