using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Data.Entities
{
    public class Meal
    { 
        [Key]
        public int? MealId { get; set; }
        public string MealName { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
