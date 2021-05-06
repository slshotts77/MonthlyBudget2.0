using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    [Authorize]
    public class PayingByController : Controller
    {
        // GET: PayingBy Index
        public ActionResult Index()
        {
            var service = new PayingByService();
            var model = service.GetPayments();
            return View(model);
        }
        //Get: PayingBy/Create/{id}
        public ActionResult Create()
        {
            return View(new PayingByCreate());
        }
        //Post: PayingBy/Create
        [HttpPost]
        public ActionResult Create(PayingByCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = new PayingByService();

            if (service.CreatePayingBy(model))
            {
                TempData["SaveResult"] = "Ppayment Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Payment could not be added");
            return View(model);
        }
        //Get: PayingBy/Detail
        public ActionResult Details(int id)
        {
            var service = new PayingByService();
            var category = service.GetPayingBy(id);
            return View(category);
        }
        //Get: PayingBy/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new PayingByService();
            var detail = service.GetPayingBy(id);
            var payingBy = new PayingByEdit() { CashOrCard = detail.CashOrCard };
            return View(payingBy);
        }
        //Post: PayingBy/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, PayingByEdit model)
        {
            var service = new PayingByService();
            if (!ModelState.IsValid)
                return View(model);

            if (service.UpdatePayingBy(id, model))
            {

                TempData["SaveResult"] = "Payment Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Payment could not be updated");
            return View(model);
        }
        //Get: PayingBy/Delete
        public ActionResult Delete(int id)
        {
            var service = new PayingByService();
            var category = service.GetPayingBy(id);
            return View(category);
        }
        //Post: PayingBy/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new PayingByService();

            if (service.DeletePayingBy(id))
            {
                TempData["SaveResult"] = "Paymnent Deleted";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Paymnet could not be updated");
            var model = service.GetPayingBy(id);
            return View(model);
        }
    }
}