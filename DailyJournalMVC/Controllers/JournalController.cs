using DailyJournal.Data.Contexts;
using DailyJournal.Data.Entities;
using DailyJournal.Models.JournalModels;
using DailyJournal.Models.ViewModels;
using DailyJournal.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyJournalMVC.Controllers
{
    [Authorize]
    public class JournalController : Controller
    {
        // GET: List of Journals
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalService(userId);
            var model = service.GetJournals();
            return View(model);
        }
       
        //GET: Create Journal
        public ActionResult Create()
        {
            var service = CreateJournalService();
            var mealsList = service.MealMenuItems();
            ViewBag.Meals = new MultiSelectList(mealsList, "Value", "Text");
            return View(new JournalData());
        }

        //POST:  Create Journal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalData viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var service = CreateJournalService();
            var mealsList = service.MealMenuItems();
            ViewBag.Meals = new MultiSelectList(mealsList, "Value", "Text");

            if (service.CreateJournal(viewModel))
            {
                TempData["SaveResult"] = "Your meal was successfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Meal could not be created.");

            return View(viewModel);
        }

       
        //GET:  Journal Details by ID

        public ActionResult Details(int id)
        {
            var svc = CreateJournalService();
            var model = svc.GetJournalById(id);

            return View(model);
        }

        //GET:  Edit Journals
        public ActionResult Edit(int id)
        {
            var service = CreateJournalService();
            var meallist = service.MealMenuItems();
            ViewBag.Meals = new MultiSelectList(meallist, "Value", "Text");
            var detail = service.GetJournalById(id);
            var viewModel = new JournalData
            {
                JournalId = detail.JournalId,
                JournalDate = detail.JournalDate,
                JournalName = detail.JournalName,
                Notes = detail.Notes,
                SelectedMealIds = detail.SelectedMealIds
            };
            return View(viewModel);
        }

        //POST Edit Journals
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JournalData viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            if (viewModel.JournalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(viewModel);
            }

            var service = CreateJournalService();
            var meallist = service.MealMenuItems();
            ViewBag.Meals = new MultiSelectList(meallist, "Value", "Text");


            if (service.UpdateJournal(viewModel))
            {
                TempData["SaveResult"] = "Your journal was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your journal could not be updated.");
            return View(viewModel);
        }

        //GET:  Delete Journals
        public ActionResult Delete (int id)
        {
            var svc = CreateJournalService();
            var model = svc.GetJournalById(id);

            return View(model);
        }

        //POST: Delete Journals
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletePost(int id)
        {
            var service = CreateJournalService();
            service.DeleteJournal(id);
            TempData["SaveResult"] = "YourJournal has been deleted.";
            return RedirectToAction("Index");
        }


        private JournalService CreateJournalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalService(userId);
            return service;
        }
    }
}