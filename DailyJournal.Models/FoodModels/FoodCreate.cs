using DailyJournal.Models.MealModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DailyJournal.Models.FoodModels
{
    public class FoodCreate
    {
        [Display(Name = "Food Item")]
        public string FoodItem { get; set; }
       
        public int Calories { get; set; }
        

    }
}
