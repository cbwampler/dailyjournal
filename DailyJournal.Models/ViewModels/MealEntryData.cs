using DailyJournal.Data.Entities;
using DailyJournal.Models.FoodModels;
using DailyJournal.Models.JournalModels;
using DailyJournal.Models.MealModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DailyJournal.Models.ViewModels
{
    public class MealEntryData
    
    {
        [Display(Name = "Meal ID")]
        public int MealId { get; set; }

        public int FoodId { get; set; }
        [Display(Name = "Meal Name")]
        public MealName MealName { get; set; }
        public WeekDay WeekDay { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meal Date")]
        public DateTime MealDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meal Time")]
        public DateTime MealTime { get; set; }
        public string Notes { get; set; }
        public IEnumerable<SelectListItem> FoodList { get; set; }
        public int[] SelectedFoodIds { get; set; }


    }
}

