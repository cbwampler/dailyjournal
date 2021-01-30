using DailyJournal.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DailyJournal.Models.MealModels
{
    public class MealEdit
    {
        public int MealId { get; set; }
        public string Notes { get; set; }
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


        public int FoodId { get; set; }
        public IEnumerable<SelectListItem> FoodList { get; set; }
        public int[] SelectedFoodIds { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public Guid OwnerId { get; set; }
        public virtual List<Food> Foods { get; set; }
    }
       
}