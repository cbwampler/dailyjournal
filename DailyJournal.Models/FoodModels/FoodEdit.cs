using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Models.FoodModels
{
    public class FoodEdit
    {
        [Display(Name = "Food ID")]
        public int FoodId { get; set; }
        [Display(Name = "Food Item")]
        public string FoodItem { get; set; }
        public int Calories { get; set; }

    }
}
