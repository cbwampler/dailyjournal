using DailyJournal.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DailyJournal.Models.JournalModels
{
    public class JournalDetail
    {
        [Display(Name = "Journal ID")]
        public int JournalId { get; set; }
        [Display(Name = "Journal Name")]
        public string JournalName { get; set; }
        public Guid OwnerId { get; set; }
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Journal Date")]
        public DateTime JournalDate { get; set; }


        public int? MealId { get; set; }

        public MealName MealName { get; set; }
        public virtual List<Meal>Meals { get; set; }
        public IEnumerable<SelectListItem> MealList { get; set; }

        public int[] SelectedMealIds { get; set; }

    }
}
