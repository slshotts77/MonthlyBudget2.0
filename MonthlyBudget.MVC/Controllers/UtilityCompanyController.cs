using MonthlyBudget.Models;
using MonthlyBudget.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyBudget.MVC.Controllers
{
    [Authorize]
    public class UtilityCompanyController : Controller
    {
        // GET: Company Index
        public ActionResult Index()
        {
            var service = new UtilityCompanyService();
            var model = service.GetCompanies();
            return View(model);
        }

        //Get: Utility Company/Create
        public ActionResult Create()
        {
            return View(new UtilityCompanyCreate());
        }

        //Post: Utility Company/Create
        [HttpPost]
        public ActionResult Create(UtilityCompanyCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = new UtilityCompanyService();

            if (service.CreateUtilityCompany(model))
            {
                TempData["SaveResult"] = "Utility Company Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Utility Company could not be added");
            return View(model);
        }

        //Get: Utility Company/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new UtilityCompanyService();
            var utilityName = service.GetUtilityCompany(id);
            return View(utilityName);
        }

        //Get: Utility Company/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = new UtilityCompanyService();
            var detail = service.GetUtilityCompany(id);
            var utilityCompany = new UtilityCompanyEdit()
                {
                    UtilityCompanyId = detail.UtilityCompanyId,
                    UtilityName = detail.UtilityName,
                    Website = detail.Website,
                    UserLogin = detail.UserLogin,
                    UserPassword = detail.UserPassword,
                    PhoneNumber = detail.PhoneNumber
                };
            return View(utilityCompany); 
        }

        //Post: Utility Company/Edit/{id}
        [HttpPost]
        public ActionResult Edit(int id, UtilityCompanyEdit model)
        {
            var service = new UtilityCompanyService();
            if (!ModelState.IsValid)
                return View(model);

            if (service.UpdateUtilityCompany(id, model))
            {

                TempData["SaveResult"] = "Utility Company Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Utility Company could not be updated");
            return View(model);
        }

        //Get: Utility Company/Delete
        public ActionResult Delete(int id)
        {
            var service = new UtilityCompanyService();
            var utilityCompany = service.GetUtilityCompany(id);
            return View(utilityCompany);
        }

        //Post: Utility Company/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = new UtilityCompanyService();

            if (service.DeleteUtilityCompany(id))
            {
                TempData["SaveResult"] = "Utility Company Deleted";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Utility Company could not be updated");
            var model = service.GetUtilityCompany(id);
            return View(model);
        }
    }
}