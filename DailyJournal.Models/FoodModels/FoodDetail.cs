using DailyJournal.Models.MealModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Models.FoodModels
{
    public class FoodDetail
    {
        public int? FoodId { get; set; }
        public string FoodName { get; set; }
        public string Serving { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbs { get; set; }
        public decimal Protein { get; set; }
        public decimal Sugar { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }
        public virtual ICollection<MealDetail> Meals { get; set; }

    }
}
