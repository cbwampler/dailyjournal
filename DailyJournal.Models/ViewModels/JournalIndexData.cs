using DailyJournal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Models.ViewModels
{
    public class JournalIndexData
    {
        public IEnumerable<Journal> Journals { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public IEnumerable<Food> Foods { get; set; }
    }
}
