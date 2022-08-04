using libraryManagementSystem.Models.Entity; //For usage of entities
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace libraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DB_LIBRARYEntities library_DB = new DB_LIBRARYEntities();
        public ActionResult Index(string searchCategory,int page=1)
        {
            //var categoryList = library_DB.category.ToList().ToPagedList(page,10);
            //return View(categoryList);
            var category = from c in library_DB.category select c;
            if (!string.IsNullOrEmpty(searchCategory))
                category = category.Where(c => c.category_name.Contains(searchCategory));
            return View(category.ToList().ToPagedList(page, 15));
        }
        [HttpGet]//for getting data
        public ActionResult addCategory()
        {
            return View();
        }

        [HttpPost]//for posting user input to the program
        public ActionResult addCategory(category categoryParam)
        {
            if (!ModelState.IsValid)
            {
                return View("addCategory");
            }
            else
            {
                library_DB.category.Add(categoryParam);
                library_DB.SaveChanges();
                return View();
            }

        }

        public ActionResult deleteCategory(int id)//parameter name must be id because we defined they must be match with {id} in the RouteConfig which defined as {id}
        {
            var delCat = library_DB.category.Find(id);//finding the category entity for the given category_id (primary key)
            library_DB.category.Remove(delCat);
            library_DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult showUpdateCategory(int id)
        {
            var updCat = library_DB.category.Find(id);
            return View("showUpdateCategory", updCat);
        }

        public ActionResult updateCategory(category updateCategory)
        {
            if (ModelState.IsValid)
            {
                var updCat = library_DB.category.Find(updateCategory.category_id);
                updCat.category_name = updateCategory.category_name;
                library_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("showUpdateCategory");
            }

        }
    }
}