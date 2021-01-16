using DailyJournal.Models.FoodModels;
using DailyJournal.Services;
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
            var service = new FoodService();
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
                FoodName = detail.FoodName,
                Serving = detail.Serving,
                Calories = detail.Calories,
                Carbs = detail.Carbs,
                Fat = detail.Fat,
                Sugar = detail.Sugar,
                Protein = detail.Protein,
                Fiber = detail.Fiber
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
            var service = new FoodService();
            return new FoodService();
        }
    }

}