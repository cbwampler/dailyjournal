using DailyJournal.Data.Contexts;
using DailyJournal.Data.Entities;
using DailyJournal.Models.MealModels;
using DailyJournal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DailyJournal.Services
{
    public class MealService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public MealService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMeal(MealEntryData viewModel)
        {

            //Create meal entity (in DB)

            var mealEntity = new Meal
            {
                OwnerId = _userId,
                MealId  = viewModel.MealId,
                Foods = new List<Food>(),
                Notes = viewModel.Notes,
                MealName = viewModel.MealName,
                WeekDay = viewModel.WeekDay,
                MealDate = viewModel.MealDate,
                MealTime = viewModel.MealTime
            };
            _db.Meals.Add(mealEntity);
            _db.SaveChanges();

            //for each foodId, find the food and add it tot he icollection for the meal

            foreach (int foodId in viewModel.SelectedFoodIds)
            {
                var food = _db.Foods.Find(foodId);
                if (food != null)
                {
                    mealEntity.Foods.Add(food);
                }
            }
            return _db.SaveChanges() == 1;
        }


            //helper class for foodlist
            public IEnumerable<SelectListItem> FoodMenuItems()
        {
        
            var foods = _db.Foods.Select(food => new SelectListItem
            {
                Value = food.FoodId.ToString(),
                Text = food.FoodItem
           
                }).ToList();

            return foods.ToList();
        }

        public IEnumerable<MealListItem> GetMeals()
        {

            var query = _db
                .Meals
                .Where(e => e.OwnerId == _userId)
                .Select(
                    e => new MealListItem
                    {
                        MealId = e.MealId,
                        MealName = e.MealName,
                        WeekDay = e.WeekDay,
                        Notes = e.Notes,
                        MealDate = e.MealDate,
                        MealTime = e.MealTime,
                        Foods = e.Foods.ToList()
                    });
               
            return query.ToArray();
        }


        public MealDetail GetMealById(int id)
        {
            var entity = _db
                .Meals
                .Single(e => e.MealId == id && e.OwnerId == _userId);
            return
                new MealDetail
                {
                    MealId = entity.MealId,
                    MealName = entity.MealName,
                    WeekDay = entity.WeekDay,
                    Notes = entity.Notes,
                    MealDate = entity.MealDate,
                    MealTime = entity.MealTime,
                    Foods = entity.Foods.ToList()
                };
        }


        public bool UpdateMeal(MealEntryData viewModel)
        {
            var entity = _db.Meals

            .Single(e => e.MealId == viewModel.MealId && e.OwnerId == _userId);

            entity.MealName = viewModel.MealName;
            entity.WeekDay = viewModel.WeekDay;
            entity.Notes = viewModel.Notes;
            entity.MealTime = viewModel.MealTime;
            entity.MealDate = viewModel.MealDate;
            

            _db.Meals.Add(entity);
            _db.SaveChanges();

            foreach (int foodId in viewModel.SelectedFoodIds)

            {
                var food = _db.Foods.Find(foodId);
                if (food != null)
                {
                    entity.Foods.Add(food);
                }
            }

            return _db.SaveChanges() == 1;
        }


        public bool DeleteMeal(int mealId)
        {

            var entity = _db
                .Meals
                .Single(e => e.MealId == mealId && e.OwnerId == _userId);

            _db.Meals.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
