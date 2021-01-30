using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJournal.Data.Entities
{
    public class Journal
    {
        public int JournalId { get; set; }
        public string JournalName { get; set; }
        public string Notes { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime JournalDate { get; set; }

        public virtual ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();

    }
}
