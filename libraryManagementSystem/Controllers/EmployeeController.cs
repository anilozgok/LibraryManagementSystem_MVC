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
    public class EmployeeController : Controller
    {

        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();

        // GET: Employee
        public ActionResult Index(string searchEmployee, int page=1)
        {
            //var employees = library_DB.employees.ToList();
            //return View(employees);
            var employee = from e in library_DB.employees select e;
            if (!string.IsNullOrEmpty(searchEmployee))
                employee = employee.Where(e => (e.employee_name + " " + e.employee_surname).Contains(searchEmployee));
            return View(employee.ToList().ToPagedList(page, 15));

        }


        [HttpGet]
        public ActionResult addEmployee()
        {
            return View();
        }


        [HttpPost]
        public ActionResult addEmployee(employees employeeParam)
        {
            if (ModelState.IsValid)
            {
                library_DB.employees.Add(employeeParam);
                library_DB.SaveChanges();
                return View();
            }
            else
            {
                return View("addEmployee");
            }
        }

        public ActionResult deleteEmployee(int id)
        {
            var delEmp = library_DB.employees.Find(id);
            library_DB.employees.Remove(delEmp);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult showUpdateEmployee(int id)
        {
            var emp = library_DB.employees.Find(id);
            return View("showUpdateEmployee", emp);
        }

        public ActionResult updateEmployee(employees empParam)
        {
            if (ModelState.IsValid)
            {
                var updEmp = library_DB.employees.Find(empParam.employee_id);
                updEmp.employee_name = empParam.employee_name;
                updEmp.employee_surname = empParam.employee_surname;
                library_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("showUpdateEmployee");
            }
        }
    }
}