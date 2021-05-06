using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    [Authorize]
    public class DescriptionController : Controller
    {
        // GET: Description Index
        public ActionResult Index()
        {
            var service = new DescriptionService();
            var model = service.GetDescriptions();
            return View(model);
        }
        //Get: Description/Create/{id}
        public ActionResult Create()
        {
            return View(new DescriptionCreate());
        }
        //Post: Description/Create
        [HttpPost]
        public ActionResult Create(DescriptionCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = new DescriptionService();

            if (service.CreateDescription(model))
            {
                ViewBag.SaveResult = "Your note was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }
        //Get: Description/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new DescriptionService();
            var description = service.GetDescription(id);
            return View(description);
        }
        //Get: Description/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new DescriptionService();
            var detail = service.GetDescription(id);
            var model =
                new DescriptionEdit
                {
                    DescriptionId = detail.DescriptionId,
                    DescriptionName = detail.DescriptionName,
                };
            return View(model);
        }
        //Post: Description/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, DescriptionEdit model)
        {
            var service = new DescriptionService();
            if (!ModelState.IsValid)
                return View(model);

            if (service.UpdateDescription(id, model))
            {

                TempData["SaveResult"] = "Description Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Description could not be updated");
            return View(model);
        }
        //Get: Description/Delete
        public ActionResult Delete(int id)
        {
            var service = new DescriptionService();
            var description = service.GetDescription(id);
            return View(description);
        }
        //Post: Description/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new DescriptionService();

            if (service.DeleteDescription(id))
            {
                TempData["SaveResult"] = "Description Deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Description could not be updated");
            var model = service.GetDescription(id);
            return View(model);
        }
    }
}