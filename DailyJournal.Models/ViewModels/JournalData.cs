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
    public class JournalData
    
    {
        [Display(Name = "Journal ID")]
        public int JournalId { get; set; }
        [Display(Name = "Journal Name")]
        public string JournalName { get; set; }    
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Journal Date")]
        public DateTime JournalDate { get; set; }
       
        public string Notes { get; set; }
        public int MealId { get; set; }
        public IEnumerable<SelectListItem> MealList { get; set; }
        public int[] SelectedMealIds { get; set; }
        public Guid OwnerId { get; set; }
        public MealName MealName { get; set; }
       

    }
}

