using DailyJournal.Data.Entities;
using DailyJournal.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Models.MealModels
{
    public class MealListItem
    {
        [Display(Name = "Meal ID")]
        public int MealId { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Meal Name")]
        public MealName MealName { get; set; }
        public WeekDay WeekDay { get; set; }

        [Display(Name = "Meal Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MealDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meal Time")]
        public DateTime MealTime { get; set; }
        public Guid OwnerId { get; set; }

        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<Food> Foods { get; set; }
    }
}