using DailyJournal.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Models.JournalModels
{
    public class JournalCreate
    {
        public int JournalId { get; set; }
        public string JournalName { get; set; }
        public Guid OwnerId { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Meal Date")]
        public DateTime JournalDate { get; set; }
        public int? MealId { get; set; }
        public MealName MealName { get; set; }

    }
}
