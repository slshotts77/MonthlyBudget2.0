using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category Index
        public ActionResult Index()
        {
            var service = new CategoryService();
            var model = service.GetCategories();
            return View(model);
        }
        //Get: Category/Create
        public ActionResult Create()
        {
            return View(new CategoryCreate());  
        }
        //Post: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = new CategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Category Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be added");
            return View(model);
        }
        //Get: Category/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new CategoryService();
            var category = service.GetCategory(id);
            return View(category);
        }
        //Get: Category/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new CategoryService();
            var detail = service.GetCategory(id);
            var category = new CategoryEdit() { CategoryName = detail.CategoryName };
            return View(category);
        }
        //Post: Category/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            var service = new CategoryService();
            if (!ModelState.IsValid)
                return View(model);

            if (service.UpdateCategory(id, model))
            {
                TempData["SaveResult"] = "Category Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be updated");
            return View(model);
        }
        //Get: Category/Delete
        public ActionResult Delete(int id)
        {
            var service = new CategoryService();
            var category = service.GetCategory(id);
            return View(category);
        }
        //Post: Category/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new CategoryService();

            if (service.DeleteCategory(id))
            {
                TempData["SaveResult"] = "Category Deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be updated");
            var model = service.GetCategory(id);
            return View(model);
        }
    }
}