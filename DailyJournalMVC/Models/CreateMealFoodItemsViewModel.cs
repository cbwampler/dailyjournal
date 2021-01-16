using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DailyJournalMVC.Models
{
    public class CreateMealFoodItemsViewModel
    {
        [Required]
        public int? MealId { get; set; }

        [Required]
        public int? FoodId { get; set; }

        public IEnumerable<SelectListItem> Foods { get; set; }
        public IEnumerable<SelectListItem> Meals  { get; set; }
    }

}