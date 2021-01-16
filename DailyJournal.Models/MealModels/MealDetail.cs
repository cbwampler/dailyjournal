using DailyJournal.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Models.MealModels
{
    public class MealDetail
    {
        public int? MealId { get; set; }
        public string MealName { get; set; }
       
        public virtual ICollection<FoodDetail> Foods { get; set; }

    }
}