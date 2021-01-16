using DailyJournal.Data;
using DailyJournal.Data.Contexts;
using DailyJournal.Data.Entities;
using DailyJournal.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Services
{
    public class FoodService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public bool CreateFood(FoodCreate model)
        {
            var entity = new Food()
            {
                FoodName = model.FoodName,
                Serving = model.Serving,
                Calories = model.Calories,
                Carbs = model.Carbs,
                Protein = model.Protein,
                Fat = model.Fat,
                Fiber = model.Fiber
            };
            _db.Foods.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            var query = _db
                .Foods
                .Select(
                    e =>
                        new FoodListItem
                        {
                            FoodId = e.FoodId,
                            FoodName = e.FoodName,
                            Serving = e.Serving,
                            Calories = e.Calories,
                            Carbs = e.Carbs,
                            Protein = e.Protein,
                            Fat = e.Fat,
                            Fiber = e.Fiber
                        }
                );
            return query.ToArray();
        }

        public FoodDetail GetFoodById(int id)
        {
            var entity = _db
                .Foods
                .Single(e => e.FoodId == id);
            return
                 new FoodDetail
                 {
                     FoodId = entity.FoodId,
                     FoodName = entity.FoodName,
                     Serving = entity.Serving,
                     Calories = entity.Calories,
                     Carbs = entity.Carbs,
                     Protein = entity.Protein,
                     Fat = entity.Fat,
                     Fiber = entity.Fiber
                 };
         }

        public bool UpdateFood(FoodEdit model)
        {
            var entity = _db
                .Foods
                .Single(e => e.FoodId == model.FoodId);

            entity.FoodId = model.FoodId;
            entity.FoodName = model.FoodName;
            entity.Serving = model.Serving;
            entity.Calories = model.Calories;
            entity.Carbs = model.Carbs;
            entity.Protein = model.Protein;
            entity.Fat = model.Fat;
            entity.Fiber = entity.Fiber;
        
            return _db.SaveChanges() == 1;
        }

        public bool DeleteFood(int foodId)
        {
           
            var entity = _db
                .Foods
                .Single(e => e.FoodId == foodId);

            _db.Foods.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}


