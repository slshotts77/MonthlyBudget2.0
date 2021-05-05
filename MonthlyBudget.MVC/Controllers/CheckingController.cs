using Microsoft.AspNet.Identity;
using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MonthlyBudget.MVC.Controllers
{
    [Authorize]
    [RoutePrefix("api/Entry")]
    public class CheckingController : Controller
    {
        // GET: Checking Index
        public ActionResult Index()
        {
            var service = CreateCheckingService();
            var model = service.GetEntries();
            return View(model);
        }
        //Get: Checking/Detail/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateCheckingService();
            var model = svc.GetEntryById(id);

            return View(model);
        }

        //Get: Checking/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Checking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckingCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateCheckingService();
            if (service.CreateChecking(model))
            {
                ViewBag.SaveResult = "Your entry was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Entry could not be created.");
            return View(model);
        }

        //Get: Checking/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCheckingService();
            var detail = service.GetEntryById(id);
            var model =
                new CheckingEdit
                {
                    CheckingId = detail.CheckingId,
                    CheckingName = detail.CheckingName,
                    MonthlyBill = detail.MonthlyBill,
                    ChargeDate = detail.ChargeDate,
                    Cleared = detail.Cleared
                };
         return View(model);
        }
        
        //Post: Checking/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CheckingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CheckingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCheckingService();

            if (service.UpdateEntry(model))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");
            return View(model);
        }

        //Get: Checking/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCheckingService();
            var model = svc.GetEntryById(id);

            return View(model);
        }

        //Post: Checking/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCheckingService();

            service.DeleteEntry(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }
        private CheckingService CreateCheckingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new CheckingService(userId);
        }
    }
}