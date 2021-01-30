using DailyJournal.Models.FoodModels;
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
    public class FoodController : Controller
    {
        // GET: List of Foods
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            var model = service.GetFoods();

            return View(model); 
        }

        //GET:  Food Create
        public ActionResult Create()
        {
            return View(new FoodCreate());
        }

        //POST:  Create Food
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFoodService();

            if (service.CreateFood(model))
            {
                TempData["SaveResult"] = "Your Food was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Food could not be created.");

            return View(model);
        }

        //GET:  Foods By Id
        public ActionResult Details(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        //GET: Edit foods
        public ActionResult Edit(int id)
        {
            var service = CreateFoodService();
            var detail = service.GetFoodById(id);
            var model = new FoodEdit
            {
                FoodId = detail.FoodId,
                FoodItem = detail.FoodItem,
                Calories = detail.Calories
            };
            
            return View(model);
        }

        //POST:  Edit Foods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodService();

            if (service.UpdateFood(model))
            {
                TempData["SaveResult"] = "Your food was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your food could not be updated.");
            return View(model);
        }

        //GET:  DELETE Foods
        public ActionResult Delete(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        //POST:  Delete Foods
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodService();
            service.DeleteFood(id);
            TempData["SaveResult"] = "Your Food has been deleted.";
            return RedirectToAction("Index");
        }

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            return new FoodService(userId);
        }
    }

}