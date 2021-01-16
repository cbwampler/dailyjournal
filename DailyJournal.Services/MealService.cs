using DailyJournal.Data;
using DailyJournal.Data.Contexts;
using DailyJournal.Data.Entities;
using DailyJournal.Models.FoodModels;
using DailyJournal.Models.MealModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public bool CreateMeal(MealCreate model)
    {
        var entity = new Meal()
        {
            OwnerId = _userId,
            MealName = model.MealName,
        };
           
            _db.Meals.Add(entity);
            return _db.SaveChanges() == 1;

            
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
                        MealName = e.MealName
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
                  
                };
            
        }
    

        public bool UpdateMeal(MealEdit model)
        {
        
            var entity = _db
                .Meals
                .Single(e => e.MealId == model.MealId && e.OwnerId == _userId);


                entity.MealName = model.MealName;
            

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



