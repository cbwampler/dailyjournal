using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Data.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodItem { get; set; }
        public int Calories { get; set; }
        public int? MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public Guid OwnerId { get; set; }
    }
}
