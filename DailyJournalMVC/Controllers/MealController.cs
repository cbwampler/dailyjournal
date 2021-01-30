using DailyJournal.Models.MealModels;
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
    public class MealController : Controller
    {
        // GET: List of Meals
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            var model = service.GetMeals();
            return View(model);
        }

        //GET:  Create Meal
        public ActionResult Create()
        {
            var service = CreateMealService();
            var foodsList = service.FoodMenuItems();
            ViewBag.Foods = new MultiSelectList(foodsList, "Value", "Text");
            return View(new MealEntryData());
        }

        //POST:  Create Meal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealEntryData viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);


            var service = CreateMealService();
            var foodsList = service.FoodMenuItems();
            ViewBag.Foods = new MultiSelectList(foodsList, "Value", "Text");

            if (service.CreateMeal(viewModel))
            {
                TempData["SaveResult"] = "Your meal was successfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Meal could not be created.");

            return View(viewModel);
        }

        //GET: Meal Details by ID
        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        //GET:  Edit Meal
        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var foodslist = service.FoodMenuItems();
            
            ViewBag.Foods = new MultiSelectList(foodslist, "Value", "Text");
               
            var detail = service.GetMealById(id);
            var viewModel = new MealEntryData
            {
                MealId = detail.MealId,
                MealName = detail.MealName,
                WeekDay = detail.WeekDay,
                MealDate = detail.MealDate,
                MealTime = detail.MealTime,
                Notes = detail.Notes,
                SelectedFoodIds = detail.SelectedFoodIds
            };       
            return View(viewModel);
        }
        //POST: Edit Meal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealEntryData viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            
            if (viewModel.MealId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(viewModel);
            }

            var service = CreateMealService();
            var foodsList = service.FoodMenuItems();
            ViewBag.Foods = new MultiSelectList(foodsList, "Value", "Text");


            if (service.UpdateMeal(viewModel))
            {
                TempData["SaveResult"] = "Your meal was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your meal could not be updated.");
            return View(viewModel);
        }
        //GET:  Delete Meal
        public ActionResult Delete(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        //POST:  Delete Meal
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, MealDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMealService();
            service.DeleteMeal(id);

            if (service.DeleteMeal(id))
            {
            TempData["SaveResult"] = "Your Meal has been successfully deleted";
            return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your meal could not be deleted.");
            return View(model);
        }

        private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            return service;
        }
    }
}
