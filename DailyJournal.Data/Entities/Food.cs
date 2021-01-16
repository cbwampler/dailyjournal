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
        [Key]
        public int? FoodId { get; set; }
        public string FoodName { get; set; }
        public string Serving { get; set; }
        public decimal Calories { get; set; }
        public decimal Carbs { get; set; }
        public decimal Sugar { get; set; }
        public decimal Protein { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }

    }
}
