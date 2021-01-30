using DailyJournal.Data.Contexts;
using DailyJournal.Data.Entities;
using DailyJournal.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyJournal.Services
{
    public class FoodService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;
        public FoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFood(FoodCreate model)
        {
            var entity = new Food()
            {
                OwnerId = _userId,
                FoodItem = model.FoodItem,
                Calories = model.Calories
            };

            _db.Foods.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            var query = _db
                .Foods
                .Where(e => e.OwnerId == _userId)
                .Select(
                    e =>
                        new FoodListItem
                        {
                            FoodId = e.FoodId,
                            FoodItem  = e.FoodItem,
                            Calories = e.Calories
                            
                        }
                );
            return query.ToArray();
        }

        public FoodDetail GetFoodById(int id)
        {
            var entity = _db
                .Foods
                .Single(e => e.FoodId == id && e.OwnerId == _userId);
            return
                 new FoodDetail
                 {
                     FoodId = entity.FoodId,
                     FoodItem = entity.FoodItem,
                     Calories = entity.Calories
                 };
         }

        public bool UpdateFood(FoodEdit model)
        {
            var entity = _db.Foods
                .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);

            entity.FoodId = model.FoodId;
            entity.FoodItem = model.FoodItem;
            entity.Calories = model.Calories;
            
            return _db.SaveChanges() == 1;
        }

        public bool DeleteFood(int foodId)
        {
           
            var entity = _db
                .Foods
                .Single(e => e.FoodId == foodId && e.OwnerId == _userId);

            _db.Foods.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}


