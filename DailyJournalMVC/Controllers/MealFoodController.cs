using DailyJournal.Data.Contexts;
using DailyJournalMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyJournalMVC.Controllers
{
    public class MealFoodController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: MealFood
        public ActionResult Index()
        {
            return View(_db.Meals.ToList());
        }

        //GET:  Create Meal Food Items
        public ActionResult Create()
        {
            var viewModel = new CreateMealFoodItemsViewModel();
            viewModel.Meals = _db.Meals.Select(meal => new SelectListItem
            {
                Text = meal.MealName,
                Value = meal.MealId.ToString()
            });

            viewModel.Foods = _db.Foods.Select(food => new SelectListItem
            {
                Text = food.FoodName,
                Value = food.FoodId.ToString()
            });

            return View(viewModel);
        }

        //POST:  Create Meal Food Item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMealFoodItemsViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}